using Common.Server;
using Common.Shared;
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
        Session ses,
        Get? req = null
    )
    {
        if (req != null && ses.Id != req.User)
        {
            // getting arbitrary users counter
            var c = await db.Counters.SingleOrDefaultAsync(x => x.User == req.User);
            ctx.NotFoundIf(c == null, model: new { Name = "Counter" });
            return c.NotNull();
        }
        // getting my counter
        var counter = await db.Counters.SingleOrDefaultAsync(x => x.User == ses.Id);
        if (counter == null)
        {
            counter = new() { User = ses.Id, Value = 0 };
            await db.AddAsync(counter);
        }

        return counter;
    }

    public static IReadOnlyList<IRpcEndpoint> Eps { get; } =
        new List<IRpcEndpoint>()
        {
            new RpcEndpoint<Get, Counter>(
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
            new RpcEndpoint<Nothing, Counter>(
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
            new RpcEndpoint<Nothing, Counter>(
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
}
