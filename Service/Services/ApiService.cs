using Dnsk.Db;
using Dnsk.Proto;
using Dnsk.Service.Util;
using Grpc.Core;
using Humanizer;
using Microsoft.Extensions.Logging;

namespace Dnsk.Service.Services;

public class ApiService : Api.ApiBase
{
    private readonly ILogger<ApiService> _log;
    private readonly DnskDb _db;
    private readonly ISessionManager _session;
    
    public ApiService(ILogger<ApiService> log, DnskDb db, ISessionManager session)
    {
        _log = log;
        _db = db;
        _session = session;
    }

    public override async  Task<Nothing> AuthRegister(AuthRegisterReq req, ServerCallContext stx)
    {
        _log.LogError("registering. ..");
        // await _db.Auths.AddAsync(new Auth()
        // {
        //     Id = Ulid.NewUlid()
        // });
        // await _db.SaveChangesAsync();
        var ses = _session.Get(stx);
        Error.If(true, StatusCode.Internal, "status detail");
        return new Nothing();
    }
}