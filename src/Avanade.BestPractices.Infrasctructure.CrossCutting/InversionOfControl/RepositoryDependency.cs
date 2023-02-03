using Avanade.BestPractices.Infrestructure.Data.Repositories.Core;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Reflection;

namespace Avanade.BestPractices.Infrasctructure.CrossCutting.InversionOfControl
{
    public static class RepositoryDependency
    {
        public static IServiceCollection AddRepositoryDependencies(this IServiceCollection services)
        {
            var type = typeof(RepositoryBase<>);
            var typeNamespace = type.Namespace?.Replace(".Core", string.Empty);

            if (string.IsNullOrEmpty(typeNamespace))
                return services;

            var allRepositoryTypes = Assembly.GetAssembly(type)?
                .GetTypes()
                .Where(type => type.Namespace != null &&
                               type.Namespace.StartsWith(typeNamespace) &&
                               type.Name.EndsWith("Repository") &&
                               type.IsClass &&
                               !type.IsAbstract)
                .ToList();

            allRepositoryTypes?.ForEach(repositoryType =>
            {
                services.AddScoped(repositoryType);

                foreach (var interfaceType in repositoryType.GetInterfaces())
                    services.AddScoped(interfaceType, x => x.GetRequiredService(repositoryType));
            });

            return services;
        }
    }
}