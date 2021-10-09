using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.Extensions.Primitives;
using Spinka.Api.Utils.Helpers;
using Spinka.Infrastructure.Database;

namespace Spinka.Api.Middlewares
{
    public class ErrorHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ErrorHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }

            catch (Exception exception)
            {
               await MiddlewareHelper.HandleErrorAsync(context, exception);
            }
        }
    }
}