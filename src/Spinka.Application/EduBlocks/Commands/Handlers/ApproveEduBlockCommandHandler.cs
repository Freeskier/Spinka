using System.Threading.Tasks;
using Spinka.Application.Dispatchers.Commands;
using Spinka.Application.Extensions;
using Spinka.Domain.Models;
using Spinka.Domain.Repositories;

namespace Spinka.Application.EduBlocks.Commands.Handlers
{
    public class ApproveEduBlockCommandHandler : ICommandHandler<ApproveEduBlock>
    {
        private readonly IUnitOfWork _unitOfWork;

        public ApproveEduBlockCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public async Task HandleAsync(ApproveEduBlock command)
        {
            var eduBlock = await _unitOfWork.Repository<EduBlock>().GetOrFailAsync(command.Id);

            if (eduBlock.Approved)
            {
                return;
            }

            eduBlock.Approved = true;

            await _unitOfWork.Repository<EduBlock>().EditAsync(eduBlock);
            await _unitOfWork.Commit();
        }
    }
}