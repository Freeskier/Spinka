using Spinka.Application.Permissions.ViewModels;
using Spinka.Domain.Models;
using Spinka.Infrastructure.Mappers;

namespace Spinka.Application.Permissions.Mappers
{
    public class PermissionMapper : IMapper<Permission, PermissionViewModel>
    {
        public PermissionViewModel MapObject(Permission entity)
        {
            return new PermissionViewModel
            {
                Id = entity.Id,
                Name = entity.Name
            };
        }
    }
}