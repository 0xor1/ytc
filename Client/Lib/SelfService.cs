using Dnsk.Common;
using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace Dnsk.Client.Lib;

public static class SelfService
{
    public static void Check(object a, object b)
    {
        Throw.If(a == b, () => new InvalidOperationException("Service can't implement itself"));
    }
}