using Common.Server.Test;
using Dnsk.Db;
using IApi = Dnsk.Api.IApi;
using S = Dnsk.I18n.S;

namespace Dnsk.Eps.Test;

public class CounterTests : IDisposable
{
    private readonly RpcTestRig<DnskDb> _rpcTestRig;

    public CounterTests()
    {
        _rpcTestRig = new RpcTestRig<DnskDb>(S.Inst, DnskEps.Eps);
    }

    [Fact]
    public async Task Counter_ShouldWork()
    {
        var (ali, _, _) = await NewApi("ali");
        var counter = await ali.Counter.Get();
        Assert.Equal(0u, counter.Value);
        counter = await ali.Counter.Increment();
        Assert.Equal(1u, counter.Value);
        counter = await ali.Counter.Decrement();
        Assert.Equal(0u, counter.Value);
        counter = await ali.Counter.Decrement();
        Assert.Equal(0u, counter.Value);
    }

    public async Task<(IApi, string Email, string Pwd)> NewApi(string? name = null) =>
        await _rpcTestRig.NewApi(rpcClient => new Api.Api(rpcClient), name);

    public void Dispose()
    {
        _rpcTestRig.Dispose();
    }
}
