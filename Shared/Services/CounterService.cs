using DnskGrpc;
using Grpc.Core;
using Microsoft.Extensions.Logging;

namespace Dnsk.Shared.Services;

public class CounterService : Counter.CounterBase
{
    private static uint _count = 0;
    private readonly ILogger<CounterService> _logger;
    
    public CounterService(ILogger<CounterService> logger)
    {
        _logger = logger;
    }

    public override Task<CountReply> Count(CountRequest request, ServerCallContext context)
    {
        _logger.LogInformation("counting...");
        return Task.FromResult(new CountReply
        {
            Count = _count++
        });
    }
}