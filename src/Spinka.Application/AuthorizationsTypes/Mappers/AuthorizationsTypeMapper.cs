using Spinka.Application.AuthorizationTypes.ViewModels;
using Spinka.Domain.Models;
using Spinka.Infrastructure.Mappers;

namespace Spinka.Application.AuthorizationsTypes.Mappers
{
    public class AuthorizationsTypeMapper : IMapper<AuthorizationsType, AuthorizationsTypeViewModel>
    {
        public AuthorizationsTypeViewModel MapObject(AuthorizationsType entity)
        {
            return new AuthorizationsTypeViewModel
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }
    }
}