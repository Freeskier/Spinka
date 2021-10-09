using System;
using Microsoft.AspNetCore.Builder;
using Spinka.Api.Middlewares;

namespace Spinka.Api.Extensions
{
    public static class MiddlewareExtensions
    {
        public static void UseErrorHandler(this IApplicationBuilder builder)
            => builder.UseMiddleware(typeof(ErrorHandlerMiddleware));
        
        public static void UseLogger(this IApplicationBuilder builder)
            => builder.UseMiddleware(typeof(LoggerMiddleware));

        public static void UseAuthorizationMiddleware(this IApplicationBuilder builder)
            => builder.UseMiddleware(typeof(AuthorizationMiddleware));
    }
}