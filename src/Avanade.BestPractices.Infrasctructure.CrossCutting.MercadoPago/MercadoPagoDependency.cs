using AutoMapper;
using Avanade.BestPractices.Infrasctructure.CrossCutting.MercadoPago.AutoMapper.Profiles;
using Microsoft.Extensions.DependencyInjection;

namespace Avanade.BestPractices.Infrasctructure.CrossCutting.MercadoPago
{
    public static class MercadoPagoDependency
    {
        public static IServiceCollection AddMercadoPagoDependencies(this IServiceCollection services)
        {
            services.AddScoped<MercadoPago>();
            services.AddScoped<PaymentProvider>();

            return services;
        }

        public static IServiceCollection AddMercadoPagoAutoMapperProfiles(this IServiceCollection services, IMapperConfigurationExpression mc)
        {
            mc.AddProfile<MercadoPagoProfile>();

            return services;
        }
    }
}
