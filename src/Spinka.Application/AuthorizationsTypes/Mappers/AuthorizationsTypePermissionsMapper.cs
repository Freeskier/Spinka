using Spinka.Application.AuthorizationTypes.ViewModels;
using Spinka.Domain.Models;
using Spinka.Infrastructure.Mappers;

namespace Spinka.Application.AuthorizationsTypes.Mappers
{
    public class AuthorizationsTypePermissionsMapper : IMapper<AuthorizationsTypePermissions, AuthorizationsTypePermissionViewModel>
    {
        public AuthorizationsTypePermissionViewModel MapObject(AuthorizationsTypePermissions entity)
        {
            return new AuthorizationsTypePermissionViewModel
            {
                PermissionId = entity.PermissionId,
                PermissionName = entity.Permission.Name,
            };
        }
    }
}