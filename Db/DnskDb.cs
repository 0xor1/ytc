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
    public DateTime LastAuthedOn { get; set; } = DateTime.UtcNow;
    public DateTime LastAuthedAttemptOn { get; set; } = DateTime.UtcNow;
    public DateTime ActivatedOn { get; set; } = new (1, 1, 1, 0, 0, 0);
    public string NewEmail { get; set; } = "";
    public string VerifyEmailCode { get; set; } = "";
    public DateTime LoginCodeCreatedOn { get; set; } = new (1, 1, 1, 0, 0, 0);
    public string LoginCode { get; set; } = "";
    public bool Use2FA { get; set; } = false;
}
public class Pwd
{
    public int PwdVersion { get; set; }
    public byte[] PwdSalt { get; set; }
    public byte[] PwdHash { get; set; }
    public int PwdIters { get; set; }
}