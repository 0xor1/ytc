using Dnsk.Db;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MySqlConnector;

namespace Dnsk.Service.Util;

public static class ServiceExts
{
    public static void AddApiServices(this IServiceCollection services)
    {
        services.AddGrpc(opts =>
        {
            opts.Interceptors.Add<ErrorInterceptor>();
        });
        services.AddScoped<ISessionManager, SessionManager>();
        services.AddDbContext<DnskDb>(
            dbContextOptions =>
            {
                var cnnStrBldr = new MySqlConnectionStringBuilder(Config.Db.Connection);
                cnnStrBldr.Pooling = true;
                cnnStrBldr.MaximumPoolSize = 100;
                cnnStrBldr.MinimumPoolSize = 1;
                var version = new MariaDbServerVersion(new Version(10, 8));
                dbContextOptions
                    .UseMySql(cnnStrBldr.ToString(), version, opts => { opts.CommandTimeout(1); });
            });
    }
}