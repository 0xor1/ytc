using Dnsk.Common;
using Dnsk.Proto;
using Grpc.Core;
using Grpc.Core.Interceptors;
using Humanizer;

namespace Dnsk.Client.Lib;

public class ErrorInterceptor : Interceptor
{
    private readonly IMainLayout _mls;
    
    public ErrorInterceptor(IMainLayoutService mls)
    {
        _mls = mls;
    }
    
    public override AsyncUnaryCall<TResponse> AsyncUnaryCall<TRequest, TResponse>(
        TRequest request,
        ClientInterceptorContext<TRequest, TResponse> context,
        AsyncUnaryCallContinuation<TRequest, TResponse> continuation)
    {
        var call = continuation(request, context);
        return new AsyncUnaryCall<TResponse>(HandleResponse(call.ResponseAsync), call.ResponseHeadersAsync, call.GetStatus, call.GetTrailers, call.Dispose);
    }

    private async Task<TResponse> HandleResponse<TResponse>(Task<TResponse> t)
    {
        try
        {
            return await t;
        }
        catch (Exception ex)
        {
            var code = StatusCode.Internal;
            var level = ToastLevel.Error;
            var message = "an unexpected error happened";
            if (ex.GetType() == typeof(RpcException))
            {
                var rpc = (RpcException)ex;
                code = rpc.Status.StatusCode;
                message = rpc.Status.Detail;
                Console.WriteLine($"{DateTime.UtcNow.ToString("s")} {code} - {message}");
            }
            else
            {
                Console.WriteLine($"{DateTime.UtcNow.ToString("s")} {ex.Message}");
            }

            _mls.PopToast(new Toast(level, message));
            // rethrow in case any other specific components need to handle it too.
            throw new ApiException(code, message);
        }
    }
}