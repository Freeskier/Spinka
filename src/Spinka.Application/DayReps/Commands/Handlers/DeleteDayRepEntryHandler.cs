using System.Threading.Tasks;
using Spinka.Application.Dispatchers.Commands;
using Spinka.Domain.Models;
using Spinka.Domain.Repositories;
using Spinka.Application.Extensions;

namespace Spinka.Application.DayReps.Commands.Handlers
{
    public class DeleteDayRepEntryHandler: ICommandHandler<DeleteDayRepEntry>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteDayRepEntryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task HandleAsync(DeleteDayRepEntry command)
        {
            foreach (var item in command.ListDayRepsId)
            {
                var dayRepEntry = await _unitOfWork.Repository<DayRep>().GetOrFailAsync(x => x.Id == item);
                await _unitOfWork.Repository<DayRep>().DeleteAsync(dayRepEntry);

            }
            await _unitOfWork.Commit();
        }
    }
}
