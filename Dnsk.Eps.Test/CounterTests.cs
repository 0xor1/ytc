using Common.Server.Test;
using Dnsk.Db;
using IApi = Dnsk.Api.IApi;
using S = Dnsk.I18n.S;

namespace Dnsk.Eps.Test;

public class CounterTests : IDisposable
{
    private readonly RpcTestRig<DnskDb, Api.Api> _rpcTestRig;

    public CounterTests()
    {
        _rpcTestRig = new RpcTestRig<DnskDb, Api.Api>(S.Inst, DnskEps.Eps, c => new Api.Api(c));
    }

    [Fact]
    public async Task Counter_Success()
    {
        var (ali, _, _) = await _rpcTestRig.NewApi("ali");
        var counter = await ali.Counter.Get();
        Assert.Equal(0u, counter.Value);
        counter = await ali.Counter.Increment();
        Assert.Equal(1u, counter.Value);
        counter = await ali.Counter.Decrement();
        Assert.Equal(0u, counter.Value);
        counter = await ali.Counter.Decrement();
        Assert.Equal(0u, counter.Value);
    }

    public void Dispose()
    {
        _rpcTestRig.Dispose();
    }
}
