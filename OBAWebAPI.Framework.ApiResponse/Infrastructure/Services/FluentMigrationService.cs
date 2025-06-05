using FluentMigrator.Runner;
using System.Reflection;

namespace OBAWebAPI.Framework.ApiResponse.Infrastructure.Services
{
    public static class FluentMigrationService
    {
        public static IServiceCollection AddFluentMigration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddFluentMigratorCore()
           .ConfigureRunner(rb => rb
               .AddSqlServer()
               .WithGlobalConnectionString(configuration.GetConnectionString("DefaultConnection"))
               .ScanIn(Assembly.GetExecutingAssembly()).For.Migrations())
           .AddLogging(lb => lb.AddFluentMigratorConsole());

            return services;
        }
        public static void RunMigrations(this IHost host)
        {
            using var scope = host.Services.CreateScope();
            var runner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();
            runner.MigrateUp();
        }
    }
}
