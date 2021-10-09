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
    public class GetMajorEventInDateQueryHandler : IQueryHandler<GetMajorEventInDate, IEnumerable<MajorEventViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper<MajorEvent, MajorEventViewModel> _mapper;

        public GetMajorEventInDateQueryHandler(IUnitOfWork unitOfWork, IMapper<MajorEvent, MajorEventViewModel> mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MajorEventViewModel>> HandleAsync(GetMajorEventInDate query)
        {
            var date = query.Date.Date;
            var majorEvents = await _unitOfWork.Repository<MajorEvent>().FindAllAsync(
                x => x.StartOn.Date <= date && x.EndOn.Date >= date && !x.IsDeleted);
            return majorEvents.Select(_mapper.MapObject).ToList();
        }
    }
}