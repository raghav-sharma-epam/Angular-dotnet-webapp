using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace API.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class CustomNewMiddleware
    {
        private readonly RequestDelegate _next;

        public CustomNewMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public Task Invoke(HttpContext httpContext)
        {
            Console.WriteLine("Http Context data is " + httpContext);
            Console.WriteLine("After content" + httpContext.Request.Method.ToString());
            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class CustomNewMiddlewareExtensions
    {
        public static IApplicationBuilder UseCustomNewMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomNewMiddleware>();
        }
    }
}
