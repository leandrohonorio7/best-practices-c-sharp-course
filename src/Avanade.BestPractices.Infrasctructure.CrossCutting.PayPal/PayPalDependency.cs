using Microsoft.Extensions.DependencyInjection;

namespace Avanade.BestPractices.Infrasctructure.CrossCutting.PayPal
{
    public static class PayPalDependency
    {
        public static IServiceCollection AddPayPalDependencies(this IServiceCollection services)
        {
            services.AddScoped<PayPal>();
            services.AddScoped<PaymentProvider>();

            return services;
        }
    }
}
