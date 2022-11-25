using Dnsk.Proto;
using Grpc.Core;
using Grpc.Core.Interceptors;

namespace Dnsk.Client.Error;

public class ErrorInterceptor : Interceptor
{
    private readonly IToasterService _ts;
    
    public ErrorInterceptor(IToasterService ts)
    {
        _ts = ts;
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
            var response = await t;
            return response;
        }
        catch (RpcException ex)
        {
            // if an exception happened pop up a toast notification to inform the user
            _ts.Show(new Toast(ToastLevel.Debug, "yolo" ));
            // then rethrow in case anything else needs to know
            throw;
        }
    }
}