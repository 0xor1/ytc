using Dnsk.Common;
using Dnsk.Proto;
using Grpc.Core;
using Grpc.Core.Interceptors;
using Humanizer;

namespace Dnsk.Client.Error;

public class ErrorInterceptor : Interceptor
{
    private const string level = "level";
    private const string message = "message";
    
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
            var l = ex.Trailers.GetValue(level);
            var msg = ex.Trailers.GetValue(message);
            // if an exception happened pop up a toast notification to inform the user
            await Do.IfAsync(level != null && msg != null, async () => await _ts.Show(new Toast(l.DehumanizeTo<MessageLevel>(), msg)));
            throw;
        }
    }
}