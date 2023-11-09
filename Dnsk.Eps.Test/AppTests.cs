using Common.Server.Test;
using Dnsk.Db;
using S = Dnsk.I18n.S;

namespace Dnsk.Eps.Test;

public class AppTests : IDisposable
{
    private readonly RpcTestRig<DnskDb, Api.Api> Rig;

    public AppTests()
    {
        Rig = new RpcTestRig<DnskDb, Api.Api>(S.Inst, DnskEps.Eps, c => new Api.Api(c));
    }

    [Fact]
    public async void GetConfig_Success()
    {
        var (ali, _, _) = await Rig.NewApi("ali");
        var c = await ali.App.GetConfig();
        Assert.True(c.IsDemo);
        Assert.Equal("https://github.com/0xor1/dnsk", c.RepoUrl);
    }

    public void Dispose()
    {
        Rig.Dispose();
    }
}
