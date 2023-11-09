using Common.Server;
using Common.Server.Auth;
using Dnsk.Db;

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
                            AppEps.OnAuthActivation,
                            AppEps.OnAuthDelete,
                            AppEps.AuthValidateFcmTopic
                        ).Eps;
                eps.AddRange(AppEps.Eps);
                eps.AddRange(CounterEps.Eps);
                _eps = eps;
            }

            return _eps;
        }
    }
}
