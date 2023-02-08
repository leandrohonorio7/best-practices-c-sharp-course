using Avanade.BestPractices.Infrasctructure.CrossCutting.MercadoPago;
using Avanade.BestPractices.Infrasctructure.CrossCutting.PayPal;
using Avanade.BestPractices.Infrestructure.Core.Payments;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Avanade.BestPractices.Infrasctructure.CrossCutting.InversionOfControl
{
    public static class InfrastructureDependency
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMercadoPagoDependencies();
            services.AddPayPalDependencies();

            services.AddTransient<PaymentProviderResolver>(serviceProvider => provider =>
            {
                return provider switch
                {
                    PaymentProviderName.MercadoPago => serviceProvider.GetService<MercadoPago.PaymentProvider>(),
                    PaymentProviderName.PayPal => serviceProvider.GetService<PayPal.PaymentProvider>(),
                    _ => throw new NotImplementedException()
                };
            });

            return services;
        }
    }
}
