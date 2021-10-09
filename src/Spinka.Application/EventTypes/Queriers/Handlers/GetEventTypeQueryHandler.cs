using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Spinka.Application.Dispatchers.Queries;
using Spinka.Application.EventTypes.ViewModels;
using Spinka.Domain.Models;
using Spinka.Domain.Repositories;
using Spinka.Infrastructure.Mappers;

namespace Spinka.Application.EventTypes.Queriers.Handlers
{
    public class GetEventTypeQueryHandler : IQueryHandler<GetEventType, EventTypeViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper<EventType, EventTypeViewModel> _mapper;

        public GetEventTypeQueryHandler(IUnitOfWork unitOfWork, IMapper<EventType, EventTypeViewModel> mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<EventTypeViewModel> HandleAsync(GetEventType query)
        {
            var eventType = await _unitOfWork.Repository<EventType>().FindByIdAsync(query.Id);
            return _mapper.MapObject(eventType);
        }
    }
}