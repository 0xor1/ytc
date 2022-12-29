using System.Security.Cryptography;
using Dnsk.Common;
using Dnsk.Db;
using Dnsk.Proto;
using Dnsk.Service.Util;
using Grpc.Core;
using Microsoft.EntityFrameworkCore;

namespace Dnsk.Service.Services;

public class ApiService : Api.ApiBase
{
    private readonly DnskDb _db;
    private readonly ISessionManager _session;
    private readonly IEmailClient _emailClient;
    
    public ApiService(DnskDb db, ISessionManager session, IEmailClient emailClient)
    {
        _db = db;
        _session = session;
        _emailClient = emailClient;
    }

    public override Task<Auth_Session> Auth_GetSession(Nothing _, ServerCallContext stx)
    {
        var ses = _session.Get(stx);
        return new Auth_Session()
        {
            Id = ses.Id,
            IsAuthed = ses.IsAuthed
        }.Task();
    }

    public override async Task<Nothing> Auth_Register(Auth_RegisterReq req, ServerCallContext stx)
    {
        // basic validation
        var ses = _session.Get(stx); 
        Error.If(ses.IsAuthed, "already in authenticated session", @public: true, log: false);
        // !!! ToLower all emails in all Auth_ api endpoints
        req.Email = req.Email.ToLower();
        Error.FromValidationResult(AuthValidator.Email(req.Email));
        Error.FromValidationResult(AuthValidator.Pwd(req.Pwd));
        
        // start db tx
        var tx = await _db.Database.BeginTransactionAsync();
        try
        {
            var existing = await _db.Auths.FirstOrDefaultAsync(x => x.Email.Equals(req.Email));
            if (existing != null)
            {
                RateLimitAuthAttempts(existing);
                return new Nothing();
            }

            var activationCode = Crypto.String();
            var pwd = Crypto.HashPwd(req.Pwd);
            await _db.Auths.AddAsync(new Auth()
            {
                Id = ses.Id,
                Email = req.Email,
                LastAuthedAttemptOn = DateTime.UtcNow,
                LastAuthedOn = DateTime.UtcNow,
                ActivatedOn = new DateTime(1, 1, 1, 0, 0, 0),
                LoginCode = activationCode,
                PwdVersion = pwd.PwdVersion,
                PwdSalt = pwd.PwdSalt,
                PwdHash = pwd.PwdHash,
                PwdIters = pwd.PwdIters
            }, stx.CancellationToken);
            await _db.SaveChangesAsync();
            await _emailClient.SendEmailAsync(
                "Confirm Email Address", 
                $"<div><a href=\"https://yolo.yolo.yolo?code={activationCode}\">please click this link to verify your email address</a></div>", 
                $"please use this link to verify your email address: https://yolo.yolo.yolo?code={activationCode}", 
                "yolo@yolo.yolo", 
                new List<string>(){req.Email});
            await tx.CommitAsync();
        }
        catch
        {
            await tx.RollbackAsync();
            throw;
        }

        return new Nothing();
    }

    public override Task<Nothing> Auth_VerifyEmail(Auth_VerifyEmailReq req, ServerCallContext stx)
    {
        // basic validation
        var ses = _session.Get(stx); 
        Error.If(ses.IsAuthed, "already in authenticated session", @public: true, log: false);
        return new Nothing().Task();
    }

    public override Task<Auth_Session> Auth_SignIn(Auth_SignInReq req, ServerCallContext stx)
    {
        var ses = _session.Get(stx);
        Error.If(ses.IsAuthed, "already in authenticated session", @public: true, log: false);
        return new Auth_Session()
        {
            Id = ses.Id,
            IsAuthed = ses.IsAuthed
        }.Task();
    }

    public override Task<Auth_Session> Auth_SignOut(Nothing _, ServerCallContext stx)
    {
        // basic validation
        var ses = _session.Get(stx);
        if (ses.IsAnon)
        {
            // not logged in, just return existing anon session
            return new Auth_Session()
            {
                Id = ses.Id,
                IsAuthed = ses.IsAuthed
            }.Task();
        }
        ses = _session.SignOut(stx);
        return new Auth_Session()
        {
            Id = ses.Id,
            IsAuthed = ses.IsAuthed
        }.Task();
    }

    private const int AuthAttemptsRateLimit = 5;
    private static void RateLimitAuthAttempts(Auth auth)
    {
        Error.If(DateTime.UtcNow.Subtract(auth.LastAuthedAttemptOn).TotalSeconds < AuthAttemptsRateLimit, $"auth attempts cannot be made more frequently than every {AuthAttemptsRateLimit} seconds", @public: true);
    }
}