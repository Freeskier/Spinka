using System.Collections.Generic;
using Spinka.Application.Dispatchers.Queries;
using Spinka.Application.Permissions.ViewModels;

namespace Spinka.Application.Permissions.Queries
{
    public class GetPersonPermissions : IQuery<IEnumerable<PermissionViewModel>>
    {
        public int PersonId { get; set; }
    }
}