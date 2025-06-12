using AspNetCoreRateLimit;
using Microsoft.AspNetCore.Diagnostics;
using OBAFramework.ApiResponse.Infrastructure.Middlewares;
using OBAFramework.ApiResponse.Infrastructure.Services;

namespace OBAFramework.ApiResponse.Infrastructure
{
    public static class Middleware
    {
        public static IApplicationBuilder AddPipeline(this IApplicationBuilder applicationBuilder, WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.RunMigrations();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseCors("EnableCORS");

            app.UseHttpsRedirection();

            app.UseIpRateLimiting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseMiddleware<ExceptionHandlingMiddleware>();
            app.UseMiddleware<LoggingMiddleware>();

            app.MapControllers();

            return applicationBuilder;
        }
    }
}
