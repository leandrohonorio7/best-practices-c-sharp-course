using Avanade.BestPractices.Infrasctructure.CrossCutting.MercadoPago;
using Avanade.BestPractices.Infrestructure.Core.Payments;
using Microsoft.Extensions.DependencyInjection;

namespace Avanade.BestPractices.Infrasctructure.CrossCutting.InversionOfControl
{
    public static class InfrastructureDependency
    {
        public static IServiceCollection AddInfrastructureDependencies(this IServiceCollection services)
        {
            #region MercadoPago
            services.AddScoped<IPaymentProvider, PaymentProvider>();
            services.AddScoped<MercadoPago.MercadoPago>();
            #endregion

            return services;
        }
    }
}
