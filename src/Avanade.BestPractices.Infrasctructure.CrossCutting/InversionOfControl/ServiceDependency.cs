using Avanade.BestPractices.Infrestructure.Data.Repositories.Core;
using Avanade.BestPractices.Service.Core;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Reflection;

namespace Avanade.BestPractices.Infrasctructure.CrossCutting.InversionOfControl
{
    public static class ServiceDependency
    {
        public static IServiceCollection AddServiceDependencies(this IServiceCollection services)
        {
            var type = typeof(ServiceBase<>);
            var typeNamespace = type.Namespace?.Replace(".Core", string.Empty);

            if (string.IsNullOrEmpty(typeNamespace))
                return services;

            var allServiceTypes = Assembly.GetAssembly(type)?
                .GetTypes()
                .Where(type => type.Namespace != null &&
                               type.Namespace.StartsWith(typeNamespace) &&
                               type.Name.EndsWith("Service") &&
                               type.IsClass &&
                               !type.IsAbstract)
                .ToList();

            allServiceTypes?.ForEach(serviceType =>
            {
                services.AddScoped(serviceType);

                foreach (var interfaceType in serviceType.GetInterfaces())
                    services.AddScoped(interfaceType, x => x.GetRequiredService(serviceType));
            });

            return services;
        }
    }
}