using Common.Shared;

namespace Dnsk.Api.Counter;

public interface ICounterApi
{
    public Task<Counter> Get();
    public Task<Counter> Increment();
    public Task<Counter> Decrement();
}

public class CounterApi : ICounterApi
{
    private readonly IRpcClient _client;

    public CounterApi(IRpcClient client)
    {
        _client = client;
    }

    public Task<Counter> Get() => _client.Do(CounterRpcs.Get, Nothing.Inst);

    public Task<Counter> Increment() => _client.Do(CounterRpcs.Increment, Nothing.Inst);

    public Task<Counter> Decrement() => _client.Do(CounterRpcs.Decrement, Nothing.Inst);
}

public static class CounterRpcs
{
    public static readonly Rpc<Nothing, Counter> Get = new("/counter/get");
    public static readonly Rpc<Nothing, Counter> Increment = new("/counter/increment");
    public static readonly Rpc<Nothing, Counter> Decrement = new("/counter/decrement");
}

public record Counter(uint Value);
