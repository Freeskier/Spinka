using System.Collections.Generic;
using Spinka.Application.AuthorizationTypes.ViewModels;
using Spinka.Application.Dispatchers.Queries;
using Spinka.Application.Persons.ViewModels;

namespace Spinka.Application.Persons.Queries
{
    public class GetPersonAuthorizationsType : IQuery<IEnumerable<PersonAuthorizationsTypeViewModel>>
    {
        public int UserId { get; set; }
    }
}