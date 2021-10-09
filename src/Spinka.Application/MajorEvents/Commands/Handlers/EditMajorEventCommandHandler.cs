
using System.Threading.Tasks;
using Spinka.Application.Dispatchers.Commands;
using Spinka.Domain.Models;
using Spinka.Domain.Repositories;

namespace Spinka.Application.MajorEvents.Commands.Handlers
{
    public class EditMajorEventCommandHandler : ICommandHandler<EditMajorEvent>
    {
        private readonly IUnitOfWork _unitOfWork;

        public EditMajorEventCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task HandleAsync(EditMajorEvent command)
        {
            var majorEvent = await _unitOfWork.Repository<MajorEvent>().FindByIdAsync(command.Id);
            var eventType = await _unitOfWork.Repository<EventType>().FindByIdAsync(command.EventTypeId);
            var unitDepartment = await _unitOfWork.Repository<UnitDepartment>().FindByIdAsync(command.UnitDepartmentId);
            majorEvent.Name = command.Name ?? majorEvent.Name;
            majorEvent.AdditionalInformation = command.AdditionalInformation ?? majorEvent.AdditionalInformation;
            majorEvent.EndOn = command.EndOn;
            majorEvent.StartOn = command.StartOn;
            majorEvent.EventType = eventType ?? majorEvent.EventType;
            majorEvent.UnitDepartment = unitDepartment ?? majorEvent.UnitDepartment;
            majorEvent.UnitDepartmentId = unitDepartment?.Id ?? majorEvent.UnitDepartmentId;
            majorEvent.EventTypeId = eventType?.Id ?? majorEvent.EventTypeId;

            await _unitOfWork.Repository<MajorEvent>().EditAsync(majorEvent);
            await _unitOfWork.Commit();
        }
    }
}