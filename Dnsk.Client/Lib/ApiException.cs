using Grpc.Core;

namespace Dnsk.Client.Lib;

public class ApiException : Exception
{
    public StatusCode Code { get; }

    public ApiException(StatusCode code, string message)
        : base(message)
    {
        Code = code;
    }
}
