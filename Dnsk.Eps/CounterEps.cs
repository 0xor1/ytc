using Common.Server;
using Common.Shared;
using Common.Shared.Auth;
using Dnsk.Api.Counter;
using Dnsk.Db;
using Microsoft.EntityFrameworkCore;
using Counter = Dnsk.Api.Counter.Counter;

namespace Dnsk.Eps;

internal static class CounterEps
{
    private static async Task<Db.Counter> GetCounter(
        IRpcCtx ctx,
        DnskDb db,
        ISession ses,
        Get? req = null
    )
    {
        if (req != null && ses.Id != req.User)
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

    public static IReadOnlyList<IEp> Eps { get; } =
        new List<IEp>()
        {
            new Ep<Get, Counter>(
                CounterRpcs.Get,
                async (ctx, req) =>
                    await ctx.DbTx<DnskDb, Counter>(
                        async (db, ses) =>
                        {
                            var counter = await GetCounter(ctx, db, ses, req);
                            return counter.ToApi();
                        },
                        false
                    )
            ),
            new Ep<Nothing, Counter>(
                CounterRpcs.Increment,
                async (ctx, _) =>
                    await ctx.DbTx<DnskDb, Counter>(
                        async (db, ses) =>
                        {
                            var counter = await GetCounter(ctx, db, ses);
                            if (counter.Value < uint.MaxValue)
                            {
                                counter.Value++;
                            }
                            var fcm = ctx.Get<IFcmClient>();
                            var res = counter.ToApi();
                            await fcm.SendTopic(ctx, db, ses, new List<string>() { ses.Id }, res);
                            return res;
                        }
                    )
            ),
            new Ep<Nothing, Counter>(
                CounterRpcs.Decrement,
                async (ctx, _) =>
                    await ctx.DbTx<DnskDb, Counter>(
                        async (db, ses) =>
                        {
                            var counter = await GetCounter(ctx, db, ses);
                            if (counter.Value > uint.MinValue)
                            {
                                counter.Value--;
                            }
                            var fcm = ctx.Get<IFcmClient>();
                            var res = counter.ToApi();
                            await fcm.SendTopic(ctx, db, ses, new List<string>() { ses.Id }, res);
                            return res;
                        }
                    )
            )
        };

    public static Task OnAuthActivation(IRpcCtx ctx, DnskDb db, string id, string email) =>
        Task.CompletedTask;

    public static Task OnAuthDelete(IRpcCtx ctx, DnskDb db, ISession ses) =>
        db.Counters.Where(x => x.User == ses.Id).ExecuteDeleteAsync(ctx.Ctkn);

    public static Task AuthValidateFcmTopic(
        IRpcCtx ctx,
        DnskDb db,
        ISession ses,
        IReadOnlyList<string> topic
    )
    {
        ctx.BadRequestIf(topic.Count != 1);
        return Task.CompletedTask;
    }
}
