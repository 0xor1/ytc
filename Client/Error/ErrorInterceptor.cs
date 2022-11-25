using Dnsk.Common;
using Dnsk.Proto;
using Grpc.Core;
using Grpc.Core.Interceptors;
using Humanizer;

namespace Dnsk.Client.Error;

public class ErrorInterceptor : Interceptor
{
    private const string LEVEL = "level";
    private const string MESSAGE = "message";
    
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
            return await t;
        }
        catch (Exception ex)
        {
            var level = MessageLevel.Error;
            var msg = "an unexpected error happened";
            if (ex.GetType() == typeof(RpcException))
            {
                var rpc = (RpcException)ex;
                var l = rpc.Trailers.GetValue(LEVEL);
                var msgStr = rpc.Trailers.GetValue(MESSAGE);
                if (l != null && msgStr != null)
                {
                    level = l.DehumanizeTo<MessageLevel>();
                    msg = msgStr;
                }
            }
            
            await _ts.Show(new Toast(level, msg));
            // rethrow in case any other specific components need to handle it too.
            throw;
        }
    }
}