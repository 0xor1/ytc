using Common.Server;
using Common.Server.Auth;
using Common.Shared;
using Dnsk.I18n;
using Microsoft.EntityFrameworkCore;

namespace Dnsk.Db;

public class DnskDb : DbContext, IAuthDb
{
    public DnskDb(DbContextOptions<DnskDb> opts)
        : base(opts) { }

    public DbSet<Auth> Auths { get; set; } = null!;
}
