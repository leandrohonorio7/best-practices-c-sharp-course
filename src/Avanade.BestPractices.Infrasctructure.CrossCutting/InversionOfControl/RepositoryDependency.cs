using Avanade.BestPractices.Infrestructure.Core.Entities.Interfaces;
using Avanade.BestPractices.Infrestructure.Data.Repositories.Core;
using Microsoft.Extensions.DependencyInjection;

namespace Avanade.BestPractices.Infrasctructure.CrossCutting.InversionOfControl
{
    public static class RepositoryDependency
    {
        public static void AddRepositoryDependencies(this IServiceCollection services)
        {
            services.AddScoped(typeof(IRepository<>), typeof(RepositoryBase<>));
        }
    }
}
