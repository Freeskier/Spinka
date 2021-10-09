using System.Linq;
using System.Threading.Tasks;
using Spinka.Application.Dispatchers.Commands;
using Spinka.Domain.Models;
using Spinka.Domain.Repositories;

namespace Spinka.Application.MajorEvents.Commands.Handlers
{
    public class AddEduBlockToMajorEventCommandHandler : ICommandHandler<AddEduBlockToMajorEvent>
    {
        private readonly IUnitOfWork _unitOfWork;

        public AddEduBlockToMajorEventCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task HandleAsync(AddEduBlockToMajorEvent command)
        {
            var majorEvent = await _unitOfWork.Repository<MajorEvent>().FindByIdAsync(command.MajorEventId);
            var eduBlock = await _unitOfWork.Repository<EduBlock>().FindByIdAsync(command.EduBlockId);
            majorEvent.EduBlocks.ToList().Add(eduBlock);
            eduBlock.MajorEventId = majorEvent.Id;
            await _unitOfWork.Commit();
        }
    }
}