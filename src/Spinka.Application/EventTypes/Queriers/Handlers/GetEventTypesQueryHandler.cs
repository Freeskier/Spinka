using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Spinka.Application.Dispatchers.Queries;
using Spinka.Application.EventTypes.ViewModels;
using Spinka.Application.MajorEvents.ViewModels;
using Spinka.Domain.Models;
using Spinka.Domain.Repositories;
using Spinka.Infrastructure.Mappers;

namespace Spinka.Application.EventTypes.Queriers.Handlers
{
    public class GetEventTypesQueryHandler : IQueryHandler<GetEventTypes, IEnumerable<EventTypeViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper<EventType, EventTypeViewModel> _mapper;

        public GetEventTypesQueryHandler(IUnitOfWork unitOfWork, IMapper<EventType, EventTypeViewModel> mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<IEnumerable<EventTypeViewModel>> HandleAsync(GetEventTypes query)
        {
            var eventTypes = await _unitOfWork.Repository<EventType>()
                .FindAllAsync(x => x.IsDeleted == false);
            
            return eventTypes.Select(_mapper.MapObject);
        }
    }
}