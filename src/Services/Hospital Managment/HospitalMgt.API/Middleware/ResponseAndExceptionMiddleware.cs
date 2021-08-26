using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace HospitalMgt.API.Middleware
{
    public class ResponseAndExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ResponseAndExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            await context.Response.WriteAsync("Hello World!");

            // Call the next delegate/middleware in the pipeline
            //await _next(context);
        }
    }

    public static class ResponseAndExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseMyMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ResponseAndExceptionMiddleware>();
        }
    }
}
