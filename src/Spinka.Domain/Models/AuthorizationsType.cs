using System.Collections.Generic;

namespace Spinka.Domain.Models
{
    public class AuthorizationsType : BaseEntity
    {
        public string Name { get; set; }

        private ISet<PersonAuthorization> _personAuthorizations = new HashSet<PersonAuthorization>();
        public IEnumerable<PersonAuthorization> PersonAuthorizations => _personAuthorizations;
        private ISet<PersonAuthorisedForEduBlockFunction> _personAuthorisedForEduBlockFunctions = new HashSet<PersonAuthorisedForEduBlockFunction>();
        public IEnumerable<PersonAuthorisedForEduBlockFunction> PersonAuthorisedForEduBlockFunctions => _personAuthorisedForEduBlockFunctions;

        private ISet<AuthorizationsTypePermissions> _authorizationsTypePermissions =
            new HashSet<AuthorizationsTypePermissions>();
        public IEnumerable<AuthorizationsTypePermissions> AuthorizationsTypePermissions =>
            _authorizationsTypePermissions;
    }
}