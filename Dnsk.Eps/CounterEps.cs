using Common.Server;
using Common.Shared;
using Dnsk.Api.Counter;
using Dnsk.Db;
using Microsoft.EntityFrameworkCore;
using Counter = Dnsk.Api.Counter.Counter;

namespace Dnsk.Eps;

internal static class CounterEps
{
    private static async Task<Db.Counter> GetCounter(DnskDb db, Session ses)
    {
        var counter = await db.Counters.SingleOrDefaultAsync(x => x.User == ses.Id);
        if (counter == null)
        {
            counter = new(){User = ses.Id, Value = 0};
            await db.AddAsync(counter);
        }

        return counter;
    }
    public static IReadOnlyList<IRpcEndpoint> Eps { get; } = new List<IRpcEndpoint>()
    {
        new RpcEndpoint<Nothing, Counter>(CounterRpcs.Get, async (ctx, _) =>
            await ctx.DbTx<DnskDb, Counter>(async (db, ses) =>
            {
                var counter = await GetCounter(db, ses);
                return counter.ToApi();
            })),
        
        new RpcEndpoint<Nothing, Counter>(CounterRpcs.Increment, async (ctx, _) =>
            await ctx.DbTx<DnskDb, Counter>(async (db, ses) =>
            {
                var counter = await GetCounter(db, ses);
                if (counter.Value < uint.MaxValue)
                {
                    counter.Value++;
                }
                return counter.ToApi();
            })),
        
        new RpcEndpoint<Nothing, Counter>(CounterRpcs.Decrement, async (ctx, _) =>
            await ctx.DbTx<DnskDb, Counter>(async (db, ses) =>
            {
                var counter = await GetCounter(db, ses);
                if (counter.Value > uint.MinValue)
                {
                    counter.Value--;
                }
                return counter.ToApi();
            }))
    };
}