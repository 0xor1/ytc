using Common.Server.Auth;
using Microsoft.EntityFrameworkCore;
using ApiCounter = Ytc.Api.Counter.Counter;

namespace Ytc.Db;

public class YtcDb : DbContext, IAuthDb
{
    public YtcDb(DbContextOptions<YtcDb> opts)
        : base(opts) { }

    public DbSet<Auth> Auths { get; set; } = null!;

    public DbSet<FcmReg> FcmRegs { get; set; } = null!;
    public DbSet<Counter> Counters { get; set; } = null!;
}

[PrimaryKey(nameof(User))]
public class Counter
{
    public string User { get; set; }
    public uint Value { get; set; }

    public ApiCounter ToApi() => new(User, Value);
}
