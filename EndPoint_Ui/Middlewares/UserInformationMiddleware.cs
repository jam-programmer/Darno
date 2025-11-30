using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;
using System.Threading.Tasks;

namespace EndPoint_Ui.Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class UserInformationMiddleware
    {

        private readonly RequestDelegate _next;

        public UserInformationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            string userAgent = httpContext.Request.Headers["User-Agent"];
            string ip = httpContext.Connection.RemoteIpAddress.ToString();
            string userInformation = httpContext.User.FindFirst("id")?.Value;

            Stopwatch sw = Stopwatch.StartNew();
            await _next(httpContext);

            sw.Stop();
            int statuscode = httpContext.Response.StatusCode;
            TimeSpan duration = sw.Elapsed;

        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class UserInformationMiddlewareExtensions
    {
        public static IApplicationBuilder UseUserInformationMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<UserInformationMiddleware>();
        }
    }
}
