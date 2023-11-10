using Common.Server;
using Common.Shared;
using Dnsk.Api.App;
using Dnsk.Db;
using Microsoft.EntityFrameworkCore;
using Config = Dnsk.Api.App.Config;
using Session = Common.Server.Session;

namespace Dnsk.Eps;

internal static class AppEps
{
    public static IReadOnlyList<IRpcEndpoint> Eps { get; } =
        new List<IRpcEndpoint>()
        {
            new RpcEndpoint<Nothing, Config>(
                AppRpcs.GetConfig,
                async (ctx, _) =>
                {
                    await Task.CompletedTask;
                    var conf = ctx.Get<IConfig>();
                    return new Config(conf.Client.DemoMode, conf.Client.RepoUrl);
                }
            )
        };

    public static Task OnAuthActivation(IRpcCtx ctx, DnskDb db, string id, string email) =>
        Task.CompletedTask;

    public static Task OnAuthDelete(IRpcCtx ctx, DnskDb db, Session ses) =>
        db.Counters.Where(x => x.User == ses.Id).ExecuteDeleteAsync(ctx.Ctkn);

    public static Task AuthValidateFcmTopic(
        IRpcCtx ctx,
        DnskDb db,
        Session ses,
        IReadOnlyList<string> topic
    )
    {
        ctx.BadRequestIf(topic.Count != 1);
        return Task.CompletedTask;
    }
}
