using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;

namespace Spinka.Api.Attributes
{
    public class ClaimRequirementAttribute  : TypeFilterAttribute
    {

        public ClaimRequirementAttribute (string claimType, string claimValue) : base(typeof(ClaimRequirementFilter))
        {
            Arguments = new object[] {new Claim(claimType, claimValue) };
        }
    }
    
    public class ClaimRequirementFilter : IAuthorizationFilter
    {
        readonly Claim _claim;

        public ClaimRequirementFilter(Claim claim)
        {
            _claim = claim;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var token = context.HttpContext.Request.Headers["Token"];
                //"eyJhbGciOiJIUzUxMiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMDAxIiwidW5pcXVlX25hbWUiOiJzdC4gc3plci4gUGlvdHIgWmR1biAvMTQ1MS8iLCJBbXVuaWNqYS5SIjoiQW11bmljamEuUiIsIkFtdW5pY2phLlciOiJBbXVuaWNqYS5XIiwibmJmIjoxNjI2ODY0MTA2LCJleHAiOjE2MjY4Njc3MDYsImlhdCI6MTYyNjg2NDEwNiwiaXNzIjoiaHR0cDovL2xvY2FsaG9zdDo1MDAxIn0.VzNYokT_Urx006dcKv1I7gC5CEmAXlIe58RRyjKDeVC3iU1D7nNRaP0ck6D8_f-v8sWkfVDn51TfwJFTDmnl5w";
            if (!StringValues.IsNullOrEmpty(token))
            {
                var decodedToken = new JwtSecurityToken((token));
                var hasClaim = decodedToken.Claims.Any(c => c.Type == _claim.Type && c.Value == _claim.Value);
                if (!hasClaim)
                {
                    context.Result = new ForbidResult();
                }
            }
            else
            {
                context.Result = new ForbidResult();
            }
        }
    }
}