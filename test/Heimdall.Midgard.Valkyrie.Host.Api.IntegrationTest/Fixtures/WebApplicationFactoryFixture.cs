using System.Data.Common;
using System.IO;
using System.Linq;
using Heimdall.Midgard.Valkyrie.Infrastructure.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;

namespace Heimdall.Midgard.Valkyrie.Host.Api.IntegrationTest.Fixtures;

public class CustomWebApplicationFactory<TProgram> : WebApplicationFactory<TProgram> where TProgram : class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            var host = Path.Exists("/.dockerenv") ? "database" : "localhost";
            var dbContextDescriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<ApplicationContext>));
            
            services.Remove(dbContextDescriptor);  
            
            var dbConnectionDescriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbConnection));

            services.Remove(dbConnectionDescriptor);

            services.AddSingleton<DbConnection>(container =>
            {
                return new NpgsqlConnection($"User ID=postgres;Password=local;Host={host};Port=5432;Database=postgres");
            });

            services.AddDbContext<ApplicationContext>((container, options) =>
            {
                options.UseNpgsql(container.GetRequiredService<DbConnection>(), npgsqlOptions =>
                {
                    npgsqlOptions.MigrationsAssembly(typeof(ApplicationContext).Assembly.GetName().Name);
                    npgsqlOptions.MigrationsHistoryTable(typeof(ApplicationContext).Assembly.GetName().Name + "_MigrationHistory");
                });
            });
        });
        
        builder.UseEnvironment("Development");
    }
}