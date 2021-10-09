using System.Threading.Tasks;
using Spinka.Application.Dispatchers.Commands;
using Spinka.Application.Extensions;
using Spinka.Domain.Models;
using Spinka.Domain.Repositories;

namespace Spinka.Application.EduBlocks.Commands.Handlers
{
    public class CancelEduBlockCommandHandler : ICommandHandler<CancelEduBlock>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CancelEduBlockCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task HandleAsync(CancelEduBlock command)
        {
            var eduBlock = await _unitOfWork.Repository<EduBlock>().GetOrFailAsync(command.Id);

            if (eduBlock.IsDeleted)
            {
                return;
            }

            eduBlock.CancellReason = command.CancellReason;
            eduBlock.IsCancelled = true;

            await _unitOfWork.Repository<EduBlock>().EditAsync(eduBlock);
            await _unitOfWork.Commit();
        }
    }
}