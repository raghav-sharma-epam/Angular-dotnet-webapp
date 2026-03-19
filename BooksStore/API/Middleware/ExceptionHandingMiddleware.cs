using API.DTO;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mime;
using System.Text.Json;
using System.Threading.Tasks;

namespace API.Middleware
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ExceptionHandingMiddleware
    {
        private readonly RequestDelegate _next;
        //  
        public ExceptionHandingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync (HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch(Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }

        }


        public async Task HandleExceptionAsync(HttpContext httpContext, Exception ex)
        {
            //ExceptionResponse response = new ExceptionResponse("","")
            //    switch
            //{
            //    ApplicationException _ => new ExceptionResponse(HttpStatusCode.BadRequest, "Application exception occurred."),
            //    KeyNotFoundException _ => new ExceptionResponse(HttpStatusCode.NotFound, "The request key not found."),
            //    UnauthorizedAccessException _ => new ExceptionResponse(HttpStatusCode.Unauthorized, "Unauthorized."),
            //    _ => new ExceptionResponse(HttpStatusCode.InternalServerError, "Internal server error. Please retry later.")

            //};
            //httpContext.Response.ContentType = "application/json";
            //httpContext.Response.StatusCode = (int)response.StatusCode;
            //await httpContext.Response.WriteAsJsonAsync(response);

            httpContext.Response.ContentType = MediaTypeNames.Application.Json;
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            var response = new ExceptionResponse(httpContext.Response.StatusCode.ToString(), ex.InnerException.Message);
            var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };

            var json = JsonSerializer.Serialize(response, options);
            await httpContext.Response.WriteAsync(json);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ExceptionHandingMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionHandingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandingMiddleware>();
        }
    }
}
