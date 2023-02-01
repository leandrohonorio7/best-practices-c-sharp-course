using Avanade.BestPractices.Infrestructure.Core.Entities.Interfaces;
using Avanade.BestPractices.Service.Core;
using Microsoft.Extensions.DependencyInjection;

namespace Avanade.BestPractices.Infrasctructure.CrossCutting.InversionOfControl
{
    public static class ServiceDependency
    {
        public static void AddServiceDependecies(this IServiceCollection services)
        {
            services.AddScoped(typeof(IService<>), typeof(ServiceBase<>));
        }
    }
}
