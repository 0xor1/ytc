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
    
    public ApiService(DnskDb db, ISessionManager session)
    {
        _db = db;
        _session = session;
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
        var ses = _session.Get(stx); 
        Error.If(ses.IsAuthed, "already in authenticated session", @public: true, log: false);
        // !!! ToLower all emails in all Auth_ api endpoints
        req.Email = req.Email.ToLower();
        Error.FromValidationResult(AuthValidator.Email(req.Email));
        Error.FromValidationResult(AuthValidator.Pwd(req.Pwd));
        var existing = await _db.Auths.FirstOrDefaultAsync( x=> x.Email.Equals(req.Email));
        if (existing != null)
        {
            // email is already associated with an existing account
            // send an email to notify the user of attempted registration
            // and silently return success
            // TODO
            return new Nothing();
        }
        // TODO: generate cryptographically strong activation code;
        var activationCode = "123123";
        // TODO: generate salt and hash pwd and store in db
        await _db.Auths.AddAsync(new Auth()
        {
            // is it ok to use existing anon ses id? it should be unique
            // and there'll be an error inserting to db if it isnt
            Id = ses.Id,
            Email = req.Email,
            LastAuthedOn = DateTime.UtcNow,
            ActivatedOn = new DateTime(1, 1, 1, 0, 0, 0),
            ActivateCode = activationCode,
        }, stx.CancellationToken);
        // TODO send activation email with link
        await _db.SaveChangesAsync();
        return new Nothing();
    }

    public override Task<Nothing> Auth_VerifyEmail(Auth_VerifyEmailReq req, ServerCallContext stx)
    {
        var ses = _session.Get(stx);
        Error.If(true, "status detail");
        return new Nothing().Task();
    }

    public override Task<Auth_Session> Auth_SignIn(Auth_SignInReq req, ServerCallContext stx)
    {
        var ses = _session.Get(stx);
        Error.If(true, "status detail");
        return new Auth_Session()
        {
            Id = ses.Id,
            IsAuthed = ses.IsAuthed
        }.Task();
    }

    public override Task<Auth_Session> Auth_SignOut(Nothing _, ServerCallContext stx)
    {
        var ses = _session.Get(stx);
        Error.If(true, "status detail");
        return new Auth_Session()
        {
            Id = ses.Id,
            IsAuthed = ses.IsAuthed
        }.Task();
    }
}