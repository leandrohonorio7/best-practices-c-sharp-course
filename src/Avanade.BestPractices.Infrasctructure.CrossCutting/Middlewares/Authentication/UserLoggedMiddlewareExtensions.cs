using Microsoft.AspNetCore.Builder;

namespace Avanade.BestPractices.Infrasctructure.CrossCutting.Middlewares.Authentication
{
    public static class UserLoggedMiddlewareExtensions
    {
        public static IApplicationBuilder IdentityUserLogged(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<UserLoggedMiddleware>();
        }
    }
}
