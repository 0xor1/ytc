using Common.Server;
using Common.Shared;
using Common.Shared.Auth;
using Ytc.Api.Counter;
using Ytc.Db;
using Microsoft.EntityFrameworkCore;
using Counter = Ytc.Api.Counter.Counter;

namespace Ytc.Eps;

internal static class CounterEps
{
    public static IReadOnlyList<IEp> Eps { get; } =
        new List<IEp>()
        {
            Ep<Get, Counter>.DbTx<YtcDb>(CounterRpcs.Get, Get, false),
            Ep<Nothing, Counter>.DbTx<YtcDb>(CounterRpcs.Increment, Increment),
            Ep<Nothing, Counter>.DbTx<YtcDb>(CounterRpcs.Decrement, Decrement)
        };

    private static async Task<Counter> Get(IRpcCtx ctx, YtcDb db, ISession ses, Get req)
    {
        var counter = await GetCounter(ctx, db, ses, req);
        return counter.ToApi();
    }

    private static async Task<Counter> Increment(
        IRpcCtx ctx,
        YtcDb db,
        ISession ses,
        Nothing req
    ) => await Crement(ctx, db, ses, true);

    private static async Task<Counter> Decrement(
        IRpcCtx ctx,
        YtcDb db,
        ISession ses,
        Nothing req
    ) => await Crement(ctx, db, ses, false);

    private static async Task<Counter> Crement(IRpcCtx ctx, YtcDb db, ISession ses, bool up)
    {
        var counter = await GetCounter(ctx, db, ses);
        if (up && counter.Value < uint.MaxValue)
        {
            counter.Value++;
        }
        else if (!up && counter.Value > uint.MinValue)
        {
            counter.Value--;
        }
        var fcm = ctx.Get<IFcmClient>();
        var res = counter.ToApi();
        await fcm.SendTopic(ctx, db, ses, new List<string>() { ses.Id }, res);
        return res;
    }

    private static async Task<Db.Counter> GetCounter(
        IRpcCtx ctx,
        YtcDb db,
        ISession ses,
        Get? req = null
    )
    {
        if (req != null && req.User != null && ses.Id != req.User)
        {
            // getting arbitrary users counter
            var c = await db.Counters.SingleOrDefaultAsync(x => x.User == req.User, ctx.Ctkn);
            ctx.NotFoundIf(c == null, model: new { Name = "Counter" });
            return c.NotNull();
        }
        // getting my counter
        var counter = await db.Counters.SingleOrDefaultAsync(x => x.User == ses.Id, ctx.Ctkn);
        if (counter == null)
        {
            counter = new() { User = ses.Id, Value = 0 };
            await db.AddAsync(counter, ctx.Ctkn);
        }

        return counter;
    }

    public static Task OnAuthActivation(IRpcCtx ctx, YtcDb db, string id, string email) =>
        Task.CompletedTask;

    public static Task OnAuthDelete(IRpcCtx ctx, YtcDb db, ISession ses) =>
        db.Counters.Where(x => x.User == ses.Id).ExecuteDeleteAsync(ctx.Ctkn);

    public static Task AuthValidateFcmTopic(
        IRpcCtx ctx,
        YtcDb db,
        ISession ses,
        IReadOnlyList<string> topic
    )
    {
        ctx.BadRequestIf(topic.Count != 1);
        return Task.CompletedTask;
    }
}
