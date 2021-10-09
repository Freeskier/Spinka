using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using Spinka.Application.Dispatchers;
using Spinka.Application.Permissions.Queries;
using Spinka.Application.Permissions.ViewModels;
using Spinka.Application.Persons.Queries;
using Spinka.Application.Persons.ViewModels;
using Spinka.Infrastructure.Auth;

namespace Spinka.Api.Middlewares
{
    public class AuthorizationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<AuthorizationMiddleware> _logger;
        private readonly IClaimsTransformation _transform;

        public AuthorizationMiddleware(RequestDelegate next, ILoggerFactory loggerFactory, IClaimsTransformation transform)
        {
            _next = next;
            _logger = loggerFactory.CreateLogger<AuthorizationMiddleware>();
            _transform = transform;
        }

        public async Task Invoke(HttpContext context, IDispatcher dispatcher, IJwtHandler jwtHandler)
        {
            var token = context.Request.Headers["Token"];
            //jeżeli użytkownik jest zidentyfikowany, a token jest nullem, to wyciągnij z bazy danych wszystkie jego pozwolenmia i na ich podstawie stwórz token
            if (context.User.Identity.IsAuthenticated && StringValues.IsNullOrEmpty(token))
            {
                if (context.User.Identity.Name != null)
                {
                    var login = context.User.Identity.Name.Split("\\")[1];
                    var person = await dispatcher.QueryAsync<GetPersonByLogin, PersonByLoginViewModel>(new GetPersonByLogin
                        {Login = login});
                    var permissions = await dispatcher.QueryAsync<GetPersonPermissions, IEnumerable<PermissionViewModel>>
                        (new GetPersonPermissions {PersonId = person.Id});
                    var permissionViewModels = permissions.ToList();
                    var generatedToken = jwtHandler.CreateToken(person.Id, person.Login, "User", permissionViewModels.Select(x => x.Name).ToList());
                    context.Response.Headers.Add("Token",generatedToken );
                }

                await _next(context);
                return;
            }
            //jeżeli w requescie jest Token, przejdz dalej
            if (!StringValues.IsNullOrEmpty(token))
            {
                await _next(context);
                return;
            }
            //zażądaj autoryzacji windowsowej 
            await context.ChallengeAsync("Windows");
        }

    }
}