using System.Collections.Generic;
using Spinka.Application.Dispatchers.Queries;
using Spinka.Application.Permissions.ViewModels;

namespace Spinka.Application.Permissions.Queries
{
    public class GetAllPermissions : IQuery<IEnumerable<PermissionViewModel>>
    {
    }
}