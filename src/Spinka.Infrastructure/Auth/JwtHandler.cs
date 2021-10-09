using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Spinka.Domain.Models;
using Spinka.Infrastructure.Options;

namespace Spinka.Infrastructure.Auth
{
    public class JwtHandler : IJwtHandler
    {
        private readonly IOptions<JwtOption> _jwtOption;

        public JwtHandler(IOptions<JwtOption> jwtOption)
        {
            _jwtOption = jwtOption;
        }
        
        public string CreateToken(int userId, string login, string role, List<string> permissions) // Refactor to object!!!
        {
            var claims = new Claim[permissions.Count + 2];
            claims[0] = new Claim(JwtRegisteredClaimNames.Sub, userId.ToString());
            claims[1] = new Claim("Login", login);
            for (int i = 0; i < permissions.Count; i++)
            {
                claims[i + 2] = new Claim(ClaimTypes.Role, permissions[i]);
            }
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOption.Value.SecretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var expires = DateTime.Now.AddMinutes(_jwtOption.Value.ExpiryMinutes);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                SigningCredentials = creds,
                Issuer = _jwtOption.Value.Issuer,
                Expires = expires,
                NotBefore = DateTime.Now
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenToReturn = tokenHandler.WriteToken(token);
            return tokenToReturn;
        }
    }
}