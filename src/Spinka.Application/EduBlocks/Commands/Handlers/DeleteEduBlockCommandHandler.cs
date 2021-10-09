using System.Threading.Tasks;
using Spinka.Application.Dispatchers.Commands;
using Spinka.Domain.Models;
using Spinka.Domain.Repositories;

namespace Spinka.Application.EduBlocks.Commands.Handlers
{
    public class DeleteEduBlockCommandHandler : ICommandHandler<DeleteEduBlock>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteEduBlockCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task HandleAsync(DeleteEduBlock command)
        {
            var eduBlock = await _unitOfWork.Repository<EduBlock>().FindByIdAsync(command.Id);
            
            if(eduBlock.IsDeleted)
                return;

            eduBlock.IsDeleted = true;
            eduBlock.CancellingRemarks = command.CancellingRemarks;

            await _unitOfWork.Repository<EduBlock>().EditAsync(eduBlock);
            await _unitOfWork.Commit();
        }
    }
}