using System;
using System.Threading.Tasks;
using Spinka.Application.Dispatchers.Commands;
using Spinka.Domain.Models;
using Spinka.Domain.Repositories;

namespace Spinka.Application.MajorEvents.Commands.Handlers
{
    public class DeleteMajorEventCommandHandler : ICommandHandler<DeleteMajorEvent>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteMajorEventCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task HandleAsync(DeleteMajorEvent command)
        {
            var majorEvent = await _unitOfWork.Repository<MajorEvent>().FindByIdAsync(command.MajorEventId);

            if (majorEvent == null) 
                throw new Exception("Major event doesn't match with given ID");
            
            majorEvent.IsDeleted = true;
            await _unitOfWork.Repository<MajorEvent>().EditAsync(majorEvent);
            await _unitOfWork.Commit();
        }
    }
}