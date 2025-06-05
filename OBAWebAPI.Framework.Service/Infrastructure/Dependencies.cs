using Microsoft.Extensions.DependencyInjection;
using NetCore.AutoRegisterDi;
using OBAWebAPI.Framework.Service.Services;
using System.Reflection;

namespace OBAWebAPI.Framework.Service.Infrastructure
{
    public static class Dependencies
    {
        public static IServiceCollection AddService(this IServiceCollection services)
        {
            var repositoryAssembly = Assembly.GetAssembly(typeof(ExampleService));
            services.RegisterAssemblyPublicNonGenericClasses(repositoryAssembly)
               .Where(c => c.Name.EndsWith("Service"))
               .AsPublicImplementedInterfaces(ServiceLifetime.Scoped);
            return services;
        }
    }
}
