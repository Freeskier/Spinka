using System.Threading.Tasks;
using Spinka.Application.Dispatchers.Commands;
using Spinka.Domain.Models;
using Spinka.Domain.Repositories;

namespace Spinka.Application.MajorEvents.Commands.Handlers
{
    public class AddMajorEventCommandHandler : ICommandHandler<CreateMajorEvent>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddMajorEventCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task HandleAsync(CreateMajorEvent command)
        {
            var majorEvent = new MajorEvent
            {
                Name = command.Name,
                StartOn = command.StartOn,
                EndOn = command.EndOn,
                AdditionalInformation = command.AdditionalInformation,
                EventTypeId = command.EventTypeId,
                UnitDepartmentId = command.UnitDepartmentId
            };

            await _unitOfWork.Repository<MajorEvent>().AddAsync(majorEvent);
            await _unitOfWork.Commit();
        }
    }
}