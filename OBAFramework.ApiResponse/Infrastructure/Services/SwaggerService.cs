using Microsoft.OpenApi.Models;

namespace OBAFramework.ApiResponse.Infrastructure.Services
{
    public static class SwaggerService
    {
        public static IServiceCollection AddSwaggerDependency(this IServiceCollection services,
        IConfiguration configuration)
        {

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(swagger =>
            {
                //This is to generate the Default UI of Swagger Documentation    
                swagger.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "OBAFramework Api",
                    Version = "v1",
                });

                var securitySchema = new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    Reference = new OpenApiReference
                    {
                        Type = ReferenceType.SecurityScheme,
                        Id = "Bearer"
                    }
                };
                swagger.AddSecurityDefinition("Bearer", securitySchema);

                var securityRequirement = new OpenApiSecurityRequirement();
                securityRequirement.Add(securitySchema, new[] { "Bearer" });
                swagger.AddSecurityRequirement(securityRequirement);
            });

            return services;
        }
    }
}
