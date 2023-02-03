using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Avanade.BestPractices.Infrasctructure.CrossCutting.Middlewares.Authentication
{
    public static class UserLoggedMiddlewareExtensions
    {
        public static IApplicationBuilder IdentityUserLogged(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<UserLoggedMiddleware>();
        }

        public static void AddIdentityUserLogged(this IServiceCollection services)
        {
            services.AddScoped<UserLoggedInfo>();
        }
    }
}
