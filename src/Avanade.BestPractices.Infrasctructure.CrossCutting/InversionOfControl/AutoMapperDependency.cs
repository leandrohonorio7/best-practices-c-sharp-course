using AutoMapper;
using Avanade.BestPractices.Infrasctructure.CrossCutting.MercadoPago;
using Microsoft.Extensions.DependencyInjection;

namespace Avanade.BestPractices.Infrasctructure.CrossCutting.InversionOfControl
{
    public static class AutoMapperDependency
    {
        public static IServiceCollection AddAutoMapperInfrastructureProfiles(this IServiceCollection services, IMapperConfigurationExpression mc)
        {
            services.AddMercadoPagoAutoMapperProfiles(mc);

            return services;
        }
    }
}
