using Microsoft.Extensions.DependencyInjection;
using NetCore.AutoRegisterDi;
using OBAFramework.Service.Services;
using System.Reflection;

namespace OBAFramework.Service.Infrastructure
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
