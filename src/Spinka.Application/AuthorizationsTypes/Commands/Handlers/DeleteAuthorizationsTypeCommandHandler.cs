using System.Threading.Tasks;
using Spinka.Application.Dispatchers.Commands;
using Spinka.Application.Persons.Commands;
using Spinka.Domain.Models;
using Spinka.Domain.Repositories;

namespace Spinka.Application.AuthorizationsTypes.Commands.Handlers
{
    public class DeleteAuthorizationsTypeCommandHandler : ICommandHandler<DeleteAuthorizationsType>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteAuthorizationsTypeCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task HandleAsync(DeleteAuthorizationsType command)
        {
            var authorizationsType = await _unitOfWork.Repository<AuthorizationsType>().FindByIdAsync(command.AuthorizationsTypeId);
            authorizationsType.IsDeleted = true;
            await _unitOfWork.Repository<AuthorizationsType>().EditAsync(authorizationsType);
            await _unitOfWork.Commit();
        }
        
    }
}