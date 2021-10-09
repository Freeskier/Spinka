using System.Threading.Tasks;
using Spinka.Application.Dispatchers.Commands;
using Spinka.Application.Extensions;
using Spinka.Domain.Repositories;
using TrainingGroupPerson = Spinka.Domain.Models.TrainingGroupsPerson;

namespace Spinka.Application.TrainingGroupsPerson.Commands.Handlers
{
    public class DeletePersonFromGroupCommandHandler : ICommandHandler<DeletePersonFromGroup>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeletePersonFromGroupCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task HandleAsync(DeletePersonFromGroup command)
        {
            var trainingGroupsPerson = await _unitOfWork.Repository<TrainingGroupPerson>().GetOrFailAsync(command.Id);

            trainingGroupsPerson.IsDeleted = true;

            await _unitOfWork.Repository<TrainingGroupPerson>().EditAsync(trainingGroupsPerson);
            await _unitOfWork.Commit();
        }
    }
}