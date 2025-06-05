namespace OBAWebAPI.Framework.ApiResponse.Infrastructure.Services
{
    public static class CorsService
    {
        public static IServiceCollection AddCorsDependency(this IServiceCollection services) 
        {
            services.AddCors(options =>
            {
                options.AddPolicy("EnableCORS", builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
            });

            return services;
        }
    }
}
