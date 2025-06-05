using AspNetCoreRateLimit;
using Microsoft.EntityFrameworkCore;
using OBAWebAPI.Framework.ApiResponse.Infrastructure.Middlewares;
using OBAWebAPI.Framework.ApiResponse.Infrastructure.Services;
using OBAWebAPI.Framework.ApiResponse.Infrastructure.Services.FileServices;
using OBAWebAPI.Framework.Repository.Infrastructure;
using OBAWebAPI.Framework.Service.Infrastructure;
using Serilog;

namespace OBAWebAPI.Framework.ApiResponse.Infrastructure
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
