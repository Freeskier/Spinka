using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using Spinka.Api.Utils.Helpers;

namespace Spinka.Api.Middlewares
{
    public class LoggerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public LoggerMiddleware(RequestDelegate next, ILoggerFactory loggerFactory)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<LoggerMiddleware>();
        }
        
        public async Task Invoke(HttpContext context)
        {
            context.Request.EnableBuffering();
            var token = context.Request.Headers["Token"];
            object user = null;
            if (!StringValues.IsNullOrEmpty(token))
            {
                var decodedToken = new JwtSecurityToken((token));
                user = new
                {
                    userName = decodedToken.Payload["Login"],
                };
            }
            else
            {
                if (context.User.Identity.Name != null)
                    user = new
                    {
                        IsAuthenticated = context.User.Identity.IsAuthenticated,
                        AuthenticationType = context.User.Identity.AuthenticationType,
                        Login = context.User.Identity.Name.Split("//")[0],
                        //Claims = context.User.Claims.Select(x => x.Value.ToString())
                    };
            }

            using var reader = new StreamReader(
                context.Request.Body,
                Encoding.UTF8,
                detectEncodingFromByteOrderMarks: false,
                bufferSize: 512, leaveOpen: true);
            var requestBody = await reader.ReadToEndAsync();
            context.Request.Body.Position = 0;
            _logger.BeginScope(new Dictionary<string, object>
            {
                ["CorrelationId"] = Guid.NewGuid(),
                ["RequestPath"] = context.Request.Path,
                ["RequestMethod"] = context.Request.Method,
                ["RequestQuery"] = context.Request.Query,
                ["RequestBody"] =requestBody,
                ["RequestContentLength"] = context.Request.ContentLength,
                ["RequestContentType"] = context.Request.ContentType,
                ["User"] = user,
                ["MachineName"] = Environment.MachineName
            });
            
            var sw = new Stopwatch();
            sw.Start();
            
            try
            {
                await _next.Invoke(context);
                
                sw.Stop();
                
                _logger.BeginScope(new Dictionary<string, object> {
                    ["ElapsedMilliseconds"] = sw.ElapsedMilliseconds
                });
                
                _logger.LogInformation("Request completed");
            }
            catch (Exception exception)
            {
                sw.Stop();
                
                _logger.BeginScope(new Dictionary<string, object> {
                    ["ElapsedMilliseconds"] = sw.ElapsedMilliseconds 
                });
                
                _logger.LogError(exception.Message, "Request Exception");
                await MiddlewareHelper.HandleErrorAsync(context, exception);
            }
        }
        
        
        
    }
}