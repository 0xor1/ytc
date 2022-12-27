using Dnsk.Common;
using Microsoft.EntityFrameworkCore;

namespace Dnsk.Db;
public class DnskDb : DbContext
{
    public DnskDb(DbContextOptions<DnskDb> opts) : base(opts) { }

    public DbSet<Auth> Auths { get; set; } = null!;
    
}

public class Auth: Pwd
{
    public string Id { get; set; }
    public string Email { get; set; }
    public DateTime LastAuthedOn { get; set; }
    public DateTime ActivatedOn { get; set; }
    public string? ActivateCode { get; set; }
    public string? NewEmail { get; set; }
    public string? NewEmailCode { get; set; }
    public DateTime? LoginCodeCreatedOn { get; set; }
    public string? LoginCode { get; set; }
    public bool Use2FA { get; set; }
}
public class Pwd
{
    public int PwdVersion { get; set; }
    public byte[] PwdSalt { get; set; }
    public byte[] PwdHash { get; set; }
    public int PwdIters { get; set; }
}