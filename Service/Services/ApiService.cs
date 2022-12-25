using Dnsk.Common;
using Dnsk.Db;
using Dnsk.Proto;
using Dnsk.Service.Util;
using Grpc.Core;
using Humanizer;
using Microsoft.Extensions.Logging;

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

    public override Task<Nothing> Auth_Register(Auth_RegisterReq req, ServerCallContext stx)
    {
        var ses = _session.Get(stx);
        Error.If(true, StatusCode.Internal, "status detail");
        return new Nothing().Task();
    }

    public override Task<Nothing> Auth_VerifyEmail(Auth_VerifyEmailReq req, ServerCallContext stx)
    {
        var ses = _session.Get(stx);
        Error.If(true, StatusCode.Internal, "status detail");
        return new Nothing().Task();
    }

    public override Task<Auth_Session> Auth_SignIn(Auth_SignInReq req, ServerCallContext stx)
    {
        // await _db.Auths.AddAsync(new Auth()
        // {
        //     Id = Ulid.NewUlid()
        // });
        // await _db.SaveChangesAsync();
        var ses = _session.Get(stx);
        Error.If(true, StatusCode.Internal, "status detail");
        return new Auth_Session()
        {
            Id = ses.Id,
            IsAuthed = ses.IsAuthed
        }.Task();
    }

    public override Task<Auth_Session> Auth_SignOut(Nothing _, ServerCallContext stx)
    {
        // await _db.Auths.AddAsync(new Auth()
        // {
        //     Id = Ulid.NewUlid()
        // });
        // await _db.SaveChangesAsync();
        var ses = _session.Get(stx);
        Error.If(true, StatusCode.Internal, "status detail");
        return new Auth_Session()
        {
            Id = ses.Id,
            IsAuthed = ses.IsAuthed
        }.Task();
    }
}