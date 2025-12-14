using Application.DataTransferObject;
using Application.Services.User;
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


        public async Task InvokeAsync(HttpContext httpContext, IUserService userService)
        {

            string Ip = string.Empty;
            string? UserAgent = httpContext.Request.Headers["User-Agent"];


            if (httpContext!.Connection.RemoteIpAddress != null)
            {

                Ip = httpContext!.Connection.RemoteIpAddress.ToString();
            }
            string? UserInformation = httpContext.User.FindFirst("id")?.Value;
            Stopwatch sw = Stopwatch.StartNew();

            await _next(httpContext);

            sw.Stop();
            int Statuscode = httpContext.Response.StatusCode;
            TimeSpan Duration = sw.Elapsed;

            await userService.SaveUserInformation(new UserInformationDto
            {
                UserAgent = UserAgent,
                Ip = Ip,
                UserInformation = UserInformation,
                Statuscode = Statuscode,

            });
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