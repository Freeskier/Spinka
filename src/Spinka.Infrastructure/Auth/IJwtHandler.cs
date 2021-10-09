using System.Collections.Generic;
using Spinka.Domain.Models;

namespace Spinka.Infrastructure.Auth
{
    public interface IJwtHandler
    {
        string CreateToken(int userId, string fullName, string role, List<string> permissions);
    }   
}