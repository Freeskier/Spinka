using System.Threading.Tasks;
using Spinka.Application.Dispatchers.Commands;
using Spinka.Domain.Models;
using Spinka.Domain.Repositories;

namespace Spinka.Application.Persons.Commands.Handlers
{
    public class AddPersonAuthorizationsTypeCommandHandler : ICommandHandler<AddPersonAuthorizationsType>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddPersonAuthorizationsTypeCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task HandleAsync(AddPersonAuthorizationsType command)
        {
            var person = await _unitOfWork.Repository<Person>().FindByIdAsync(command.PersonId);
            var authorizationsType = await 
                _unitOfWork.Repository<AuthorizationsType>().FindByIdAsync(command.AuthorizationsTypeId);
            var personAuthorization = new PersonAuthorization
            {
                Person = person,
                AuthorizationsType = authorizationsType,
                IsDeleted = false,
                PersonId = person.Id,
                AuthorizationTypeId = authorizationsType.Id,
            };

            await _unitOfWork.Repository<PersonAuthorization>().AddAsync(personAuthorization);
            await _unitOfWork.Commit();
        }
    }
}