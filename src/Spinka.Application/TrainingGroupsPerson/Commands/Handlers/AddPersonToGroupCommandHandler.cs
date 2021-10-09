using System.Threading.Tasks;
using Spinka.Application.Dispatchers.Commands;
using Spinka.Domain.Repositories;
using TrainingGroupPerson =  Spinka.Domain.Models.TrainingGroupsPerson;

namespace Spinka.Application.TrainingGroupsPerson.Commands.Handlers
{
    public class AddPersonToGroupCommandHandler : ICommandHandler<AddPersonToGroup>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddPersonToGroupCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task HandleAsync(AddPersonToGroup command)
        {
            var personExistsInGroup = await _unitOfWork.Repository<TrainingGroupPerson>()
                .FindByIdAsync(command.PersonId);

            if (personExistsInGroup != null)
            {
                personExistsInGroup.IsDeleted = false;

                await _unitOfWork.Repository<TrainingGroupPerson>().EditAsync(personExistsInGroup);
                await _unitOfWork.Commit();
            }

            var newPersonInGroup = new TrainingGroupPerson
            {
                PersonId = command.PersonId,
                TrainingGroupId = command.TrainingGroupId
            };

            await _unitOfWork.Repository<TrainingGroupPerson>().AddAsync(newPersonInGroup);
            await _unitOfWork.Commit();
        }
    }
}