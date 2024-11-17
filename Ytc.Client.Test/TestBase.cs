using Common.Client;
using Common.Server.Test;
using Ytc.Api;
using Ytc.Db;
using Ytc.Eps;
using Radzen;
using S = Ytc.I18n.S;

namespace Ytc.Client.Test;

public class TestBase : IDisposable
{
    protected readonly RpcTestRig<YtcDb, Api.Api> RpcTestRig;
    protected readonly List<TestPack> TestPacks = new();

    public TestBase()
    {
        RpcTestRig = new RpcTestRig<YtcDb, Api.Api>(S.Inst, YtcEps.Eps, c => new Api.Api(c));
    }

    protected async Task<TestPack> NewTestPack(string name)
    {
        var (api, email, pwd) = await RpcTestRig.NewApi(name);
        var ctx = new TestContext();
        var l = new Localizer(S.Inst);
        var ns = new NotificationService();
        Common.Client.Client.Setup(ctx.Services, l, S.Inst, ns, (IApi)api);
        var tp = new TestPack(api, ctx, email, pwd);
        TestPacks.Add(tp);
        return tp;
    }

    public void Dispose()
    {
        RpcTestRig.Dispose();
        TestPacks.ForEach(x => x.Ctx.Dispose());
    }
}

public record TestPack(IApi Api, TestContext Ctx, string Email, string Pwd);
