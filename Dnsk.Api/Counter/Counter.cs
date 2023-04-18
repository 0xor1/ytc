using Common.Shared;

namespace Dnsk.Api.Counter;

public interface ICounterApi
{
    private static ICounterApi? _inst;
    static ICounterApi Init() => _inst ??= new CounterApi();
    
    public Rpc<Nothing, Counter> Get { get; }
    
    public Rpc<Nothing, Counter> Increment { get; }
    public Rpc<Nothing, Counter> Decrement { get; }
}
public class CounterApi: ICounterApi
{
    public Rpc<Nothing, Counter> Get { get; } = new ("/counter/get");
    public Rpc<Nothing, Counter> Increment { get; } = new ("/counter/increment");
    public Rpc<Nothing, Counter> Decrement { get; } = new ("/counter/decrement");
}

public record Counter(uint Value);