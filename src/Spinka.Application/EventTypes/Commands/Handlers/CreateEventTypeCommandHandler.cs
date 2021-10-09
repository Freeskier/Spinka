using System.Threading.Tasks;
using Spinka.Application.Dispatchers.Commands;
using Spinka.Domain.Models;
using Spinka.Domain.Repositories;

namespace Spinka.Application.EventTypes.Commands.Handlers
{
    public class CreateEventTypeCommandHandler : ICommandHandler<CreateEventType>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateEventTypeCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task HandleAsync(CreateEventType command)
        {
            var eventType = new EventType
            {
                Acr = command.Acr,
                Color = command.Color,
                Name = command.Name
            };

            await _unitOfWork.Repository<EventType>().AddAsync(eventType);
            await _unitOfWork.Commit();
        }
    }
}