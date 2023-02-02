using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Avanade.BestPractices.Infrasctructure.CrossCutting.Middlewares.Authentication
{
    public class UserLoggedMiddleware
    {
        private readonly RequestDelegate _next;

        public UserLoggedMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var user = context.User;
            var userLoggedInfo = context.RequestServices.GetRequiredService<UserLoggedInfo>();
            var userLogged = user?.Identity?.Name;
            userLoggedInfo.UserId = userLogged ?? "System";

            await _next(context);
        }
    }
}
