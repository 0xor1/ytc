using Dnsk.Common;
using Grpc.Core;

namespace Dnsk.Service.Util;

public static class Error
{
    public static void If(bool condition, StatusCode code, string message)
    {
        if (condition)
        {
            throw new RpcException(new Status(code, message));
        }
    }
}