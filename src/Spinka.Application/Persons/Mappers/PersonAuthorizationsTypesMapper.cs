using Spinka.Application.AuthorizationTypes.ViewModels;
using Spinka.Application.Persons.ViewModels;
using Spinka.Domain.Models;
using Spinka.Infrastructure.Mappers;

namespace Spinka.Application.Persons.Mappers
{
    public class PersonAuthorizationsTypesMapper : IMapper<PersonAuthorization, PersonAuthorizationsTypeViewModel>
    {
        public PersonAuthorizationsTypeViewModel MapObject(PersonAuthorization entity)
        {
            return new PersonAuthorizationsTypeViewModel
            {
                PersonAuthorizationsId = entity.Id,
                AuthorizationsTypeId = entity.AuthorizationTypeId,
                AuthorizationsTypeName = entity.AuthorizationsType.Name,
            };
        }
    }
}