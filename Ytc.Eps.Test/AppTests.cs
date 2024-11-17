using Common.Server.Test;
using Ytc.Db;
using S = Ytc.I18n.S;

namespace Ytc.Eps.Test;

public class AppTests : IDisposable
{
    private readonly RpcTestRig<YtcDb, Api.Api> Rig;

    public AppTests()
    {
        Rig = new RpcTestRig<YtcDb, Api.Api>(S.Inst, YtcEps.Eps, c => new Api.Api(c));
    }

    [Fact]
    public async void GetConfig_Success()
    {
        var (ali, _, _) = await Rig.NewApi("ali");
        var c = await ali.App.GetConfig();
        Assert.True(c.DemoMode);
        Assert.Equal("https://github.com/0xor1/ytc", c.RepoUrl);
    }

    public void Dispose()
    {
        Rig.Dispose();
    }
}
