using System;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Spinka.Application.Exceptions;
using Spinka.Infrastructure.Exceptions;

namespace Spinka.Api.Utils.Helpers
{
    public static class MiddlewareHelper
    {
        public static Task HandleErrorAsync(HttpContext context, Exception exception)
        {
            var errorCode = "error";
            var statusCode = HttpStatusCode.InternalServerError;
            var exceptionType = exception.GetType();

            // Add other http code !!!
            switch (exception)
            {
                case { } e when exceptionType == typeof(UnauthorizedAccessException):
                    statusCode = HttpStatusCode.Unauthorized;
                    break;

                case { } e when exceptionType == typeof(ArgumentException):
                    statusCode = HttpStatusCode.BadRequest;
                    break;

                case { } e when exceptionType == typeof(TimeoutException):
                    statusCode = HttpStatusCode.RequestTimeout;
                    break;

                case BusinessException e when exceptionType == typeof(BusinessException):
                    statusCode = HttpStatusCode.BadRequest;
                    errorCode = e.Code;
                    break;
                
                case EntityNotExistsException e when exceptionType == typeof(EntityNotExistsException):
                    statusCode = HttpStatusCode.InternalServerError;
                    break;
                
                case { } e when exceptionType == typeof(Exception):
                    statusCode = HttpStatusCode.InternalServerError;
                    break;
            }

            var response = new { code = errorCode, message = exception.Message };
            var payload = JsonConvert.SerializeObject(response);
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            return context.Response.WriteAsync(payload);
        }
    }
}