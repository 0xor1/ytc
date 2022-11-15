using Microsoft.EntityFrameworkCore;

namespace Dnsk.Db;
public class DnskDb : DbContext
{
    public DnskDb(DbContextOptions<DnskDb> opts) : base(opts) { }

    public DbSet<Auth> Auths { get; set; } = null!;
    
}

public class Auth
{
    public string Id { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public DateTime LastAuthedOn { get; set; }
    public DateTime ActivatedOn { get; set; }
    public string? ActivateCode { get; set; }
    public string? NewEmail { get; set; }
    public string? NewEmailCode { get; set; }
    public string? NewPhone { get; set; }
    public string? NewPhoneCode { get; set; }
    public DateTime? LoginCodeCreatedOn { get; set; }
    public string? LoginCode { get; set; }
    public bool Use2FA { get; set; }
    public byte[]? ScryptSalt { get; set; }
    public byte[]? ScryptPwd { get; set; }
    public uint? ScryptN { get; set; } 
    public uint? ScryptR { get; set; }
    public uint? ScryptP { get; set; }
}