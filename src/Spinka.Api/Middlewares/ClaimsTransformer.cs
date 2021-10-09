using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Spinka.Application.Dispatchers;
using Spinka.Application.Persons.Queries;
using Spinka.Application.Persons.ViewModels;

namespace Spinka.Api.Middlewares
{
    public class ClaimsTransformer : IClaimsTransformation
    {
        private readonly ILogger<ClaimsTransformer> _logger;

        public ClaimsTransformer(ILoggerFactory loggerFactory )
        {
            _logger = loggerFactory.CreateLogger<ClaimsTransformer>();
        }

        public Task<ClaimsPrincipal> TransformAsync(ClaimsPrincipal principal)
        {
            var claimInfo = (ClaimsIdentity) principal.Identity;
            var c = new Claim(claimInfo.RoleClaimType, "User");
            claimInfo.AddClaim(c);
            return Task.FromResult(principal);
        }
    }
}