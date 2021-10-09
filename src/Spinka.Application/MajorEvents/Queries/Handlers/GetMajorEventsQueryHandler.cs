using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Spinka.Application.Dispatchers.Queries;
using Spinka.Application.MajorEvents.ViewModels;
using Spinka.Domain.Models;
using Spinka.Domain.Repositories;
using Spinka.Infrastructure.Mappers;

namespace Spinka.Application.MajorEvents.Queries.Handlers
{
    public class GetMajorEventsQueryHandler : IQueryHandler<GetMajorEvents, IEnumerable<MajorEventViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper<MajorEvent, MajorEventViewModel> _mapper;

        public GetMajorEventsQueryHandler(IUnitOfWork unitOfWork, IMapper<MajorEvent, MajorEventViewModel> mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MajorEventViewModel>> HandleAsync(GetMajorEvents query)
        {
            var majorEvents = await _unitOfWork.Repository<MajorEvent>()
                .FindAllAsync(x => x.IsDeleted == false);
            
            return majorEvents.Select(_mapper.MapObject);
        }
    }
}