using Common.Server;
using Common.Server.Auth;
using Dnsk.Db;
using Microsoft.EntityFrameworkCore;

namespace Dnsk.Eps;

public static class DnskEps
{
    private static IReadOnlyList<IRpcEndpoint>? _eps;
    public static IReadOnlyList<IRpcEndpoint> Eps
    {
        get
        {
            if (_eps == null)
            {
                var eps =
                    (List<IRpcEndpoint>)
                        new AuthEps<DnskDb>(
                            5,
                            (db, ses) =>
                                db.Counters.Where(x => x.User == ses.Id).ExecuteDeleteAsync()
                        ).Eps;
                eps.AddRange(CounterEps.Eps);
                _eps = eps;
            }

            return _eps;
        }
    }
}
