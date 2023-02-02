using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Avanade.BestPractices.Infrasctructure.CrossCutting.Middlewares.Authentication;
using Avanade.BestPractices.Infrestructure.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Avanade.BestPractices.Infrasctructure.CrossCutting.InversionOfControl
{
    public static class EntityDependency
    {
        public static IServiceCollection AddEntityDependency(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(serviceProvider =>
            {
                var connectionString = configuration.GetConnectionString("BestPractices");
                var options = new DbContextOptionsBuilder<EntityContext>()
                    .UseSqlServer(connectionString)
                    .Options;
                var userLoggedInfo = (UserLoggedInfo)serviceProvider.GetService(typeof(UserLoggedInfo));
                var context = new EntityContext(options, userLoggedInfo?.UserId);
                return context;
            });

            return services;
        }
    }
}
