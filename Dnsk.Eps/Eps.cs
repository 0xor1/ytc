using Common.Server;
using Common.Server.Auth;
using Dnsk.Db;

namespace Dnsk.Eps;

public static class DnskEps
{
    private static IReadOnlyList<IRpcEndpoint>? _eps;
    public static IReadOnlyList<IRpcEndpoint> Eps => _eps ??= AuthEps<DnskDb>.Eps;
}