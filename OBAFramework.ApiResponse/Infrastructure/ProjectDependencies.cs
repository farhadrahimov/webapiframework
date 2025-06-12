using AspNetCoreRateLimit;
using Microsoft.EntityFrameworkCore;
using OBAFramework.ApiResponse.Infrastructure.Middlewares;
using OBAFramework.ApiResponse.Infrastructure.Services;
using OBAFramework.ApiResponse.Infrastructure.Services.FileServices;
using OBAFramework.Repository.Infrastructure;
using OBAFramework.Service.Infrastructure;
using Serilog;

namespace OBAFramework.ApiResponse.Infrastructure
{
    public static class ProjectDependencies
    {
        public static IServiceCollection AddProjectDependencies(this IServiceCollection services, IConfiguration configuration,
            WebApplicationBuilder builder)
        {
            builder.Host.UseSerilog();  
            services.AddCorsDependency();
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddRepository().AddService();
            services.AddMemoryCache();
            services.Configure<IpRateLimitOptions>(configuration.GetSection("IpRateLimiting"));
            services.AddAuthenticationService(configuration);
            services.AddInMemoryRateLimiting();
            services.AddFluentMigration(configuration);
            services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
            services.AddTransient<IRequestLogger, RequestLogger>();
            services.AddTransient<IFileService, FileService>();
            services.AddSwaggerDependency(configuration);
            services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            return services;
        }
    }
}
