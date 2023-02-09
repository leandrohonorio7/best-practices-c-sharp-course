using AutoMapper;
using Avanade.BestPractices.API.Infrasctructure.AutoMapper.Profiles;
using Avanade.BestPractices.Infrasctructure.CrossCutting.InversionOfControl;
using Microsoft.Extensions.DependencyInjection;

namespace Avanade.BestPractices.API.Infrasctructure.AutoMapper
{
    public static class AutoMapperDependency
    {
        public static IServiceCollection AddAutoMapperDependencies(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                services.AddAPIProfiles(mc);
                services.AddAutoMapperInfrastructureProfiles(mc);
            });
            var mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            return services;
        }

        private static IServiceCollection AddAPIProfiles(this IServiceCollection services, IMapperConfigurationExpression mc)
        {
            mc.AddProfile<AccountProfile>();
            mc.AddProfile<ChargeProfile>();
            mc.AddProfile<RideProfile>();

            return services;
        }
    }
}
