using System.Threading.Tasks;
using Spinka.Application.Dispatchers.Commands;
using Spinka.Domain.Models;
using Spinka.Domain.Repositories;

namespace Spinka.Application.GroupForDayReps.Commands.Handlers
{
    public class AddPersonToGroupForDayRepCommandHandler : ICommandHandler<AddPersonToGroupForDayRepCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddPersonToGroupForDayRepCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public async Task HandleAsync(AddPersonToGroupForDayRepCommand command)
        {
            var personInGroup = await _unitOfWork.Repository<DayRepGroupPerson>()
                .FindByAsync(x => x.PersonId == command.PersonId 
                && x.GroupForDayRepId == command.GroupId
                && x.IsDelegated==command.IsDelegated);

            if (personInGroup != null)
            {
                personInGroup.IsDeleted = false;

                await _unitOfWork.Repository<DayRepGroupPerson>().EditAsync(personInGroup);
                await _unitOfWork.Commit();
            }
            else
            {
                await _unitOfWork.Repository<DayRepGroupPerson>().AddAsync(new DayRepGroupPerson
                {
                    GroupForDayRepId = command.GroupId,
                    IsDeleted = false,
                    IsDelegated= command.IsDelegated,
                    PersonId = command.PersonId
                });
                await _unitOfWork.Commit();
            }
        }
    }
}
