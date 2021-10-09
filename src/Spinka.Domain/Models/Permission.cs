using System.Collections.Generic;

namespace Spinka.Domain.Models
{
    public class Permission : BaseEntity
    {
        public string Name { get; set; }
        private ISet<AuthorizationsTypePermissions> _authorizationsTypePermissions =
            new HashSet<AuthorizationsTypePermissions>();
        public IEnumerable<AuthorizationsTypePermissions> AuthorizationsTypePermissions =>
            _authorizationsTypePermissions;
    }
}