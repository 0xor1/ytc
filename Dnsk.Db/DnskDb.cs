using Common.Server.Auth;
using Microsoft.EntityFrameworkCore;
using ApiCounter = Dnsk.Api.Counter.Counter;

namespace Dnsk.Db;

public class DnskDb : DbContext, IAuthDb
{
    public DnskDb(DbContextOptions<DnskDb> opts)
        : base(opts) { }

    public DbSet<Auth> Auths { get; set; } = null!;
    public DbSet<Counter> Counters { get; set; } = null!;
}

[PrimaryKey(nameof(User))]
public class Counter
{
    public string User { get; set; }
    public uint Value { get; set; }

    public ApiCounter ToApi()
    {
        return new ApiCounter(Value);
    }
}
