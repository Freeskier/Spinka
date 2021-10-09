using System.Collections.Generic;
using Spinka.Application.AuthorizationTypes.ViewModels;
using Spinka.Application.Dispatchers.Queries;
using Spinka.Application.Permissions.ViewModels;

namespace Spinka.Application.AuthorizationsTypes.Queries
{
    public class GetAuthorizationsTypePermissions : IQuery<IEnumerable<AuthorizationsTypePermissionViewModel>>
    {
        public int AuthorizationTypeId { get; set; }
    }
}