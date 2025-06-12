﻿using Microsoft.Extensions.DependencyInjection;
using OBAFramework.Repository.Repositories;
using NetCore.AutoRegisterDi;
using System.Reflection;

namespace OBAFramework.Repository.Infrastructure
{
    public static class Dependencies
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            var repositoryAssembly = Assembly.GetAssembly(typeof(ExampleRepository));

            services.RegisterAssemblyPublicNonGenericClasses(repositoryAssembly)
                .Where(c => c.Name.EndsWith("Repository"))
                .AsPublicImplementedInterfaces(ServiceLifetime.Scoped);

            services.RegisterAssemblyPublicNonGenericClasses(repositoryAssembly)
                .Where(c => c.Name.EndsWith("Command"))
                .AsPublicImplementedInterfaces(ServiceLifetime.Scoped);

            services.RegisterAssemblyPublicNonGenericClasses(repositoryAssembly)
                .Where(c => c.Name.EndsWith("Query"))
                .AsPublicImplementedInterfaces(ServiceLifetime.Scoped);
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
