using System;
using System.Linq;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace Avanade.BestPractices.Infrestructure.Core.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddMutipleDependencies<T>(this IServiceCollection services, Type type, string serviceSufixName, string namespaceFolder = null) where T : class
        {
            var typeNamespace = string.IsNullOrEmpty(namespaceFolder) 
                ? type.Namespace
                : type.Namespace?.Replace($".{namespaceFolder}", string.Empty);

            if (string.IsNullOrEmpty(typeNamespace))
                return;

            var allServiceTypes = Assembly.GetAssembly(type)?
                .GetTypes()
                .Where(it => it.Namespace != null &&
                             it.Namespace.StartsWith(typeNamespace) &&
                             it.Name.EndsWith(serviceSufixName) &&
                             it.IsClass &&
                             !it.IsAbstract)
                .ToList();

            allServiceTypes?.ForEach(serviceType =>
            {
                services.AddScoped(serviceType);

                foreach (var interfaceType in serviceType.GetInterfaces())
                    services.AddScoped(interfaceType, it => it.GetRequiredService(serviceType));
            });
        }
    }
}
