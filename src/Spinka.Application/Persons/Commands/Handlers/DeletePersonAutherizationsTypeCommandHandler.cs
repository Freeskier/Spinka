using System.Threading.Tasks;
using Spinka.Application.Dispatchers.Commands;
using Spinka.Domain.Models;
using Spinka.Domain.Repositories;

namespace Spinka.Application.Persons.Commands.Handlers
{
    public class DeletePersonAuthorizationsTypeCommandHandler : ICommandHandler<DeletePersonAuthorizationsType>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeletePersonAuthorizationsTypeCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task HandleAsync(DeletePersonAuthorizationsType command)
        {
            var personAuthorization = await _unitOfWork.Repository<PersonAuthorization>().FindByIdAsync(command.PersonAuthorizationsId);
            personAuthorization.IsDeleted = true;
            await _unitOfWork.Repository<PersonAuthorization>().EditAsync(personAuthorization);
            await _unitOfWork.Commit();
        }
    }
}