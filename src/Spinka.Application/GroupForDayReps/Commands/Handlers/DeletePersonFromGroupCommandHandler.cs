using System.Threading.Tasks;
using Spinka.Application.Dispatchers.Commands;
using Spinka.Domain.Models;
using Spinka.Domain.Repositories;

namespace Spinka.Application.GroupForDayReps.Commands.Handlers
{
    public class DeletePersonFromGroupCommandHandler : ICommandHandler<DeletePersonFromGroupCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeletePersonFromGroupCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task HandleAsync(DeletePersonFromGroupCommand command)
        {
            var personInGroup = await _unitOfWork.Repository<DayRepGroupPerson>().FindByIdAsync(command.PersonInGroupId);
            personInGroup.IsDeleted = true;
            personInGroup.IsDelegated = false;
            await _unitOfWork.Repository<DayRepGroupPerson>().EditAsync(personInGroup);
            await _unitOfWork.Commit();
        }
    }
}
