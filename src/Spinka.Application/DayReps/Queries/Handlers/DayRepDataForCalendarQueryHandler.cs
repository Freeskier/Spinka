using Microsoft.EntityFrameworkCore;
using Spinka.Application.DayReps.ViewModels;
using Spinka.Application.Dispatchers.Queries;
using Spinka.Domain.Models;
using Spinka.Domain.Repositories;
using Spinka.Infrastructure.Mappers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spinka.Application.DayReps.Queries.Handlers
{
    public class DayRepDataForCalendarQueryHandler : IQueryHandler<DayRepDataForCalendarQuery, IEnumerable<DayRepDataForCalendarViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapperWithParams<DayRepGroupPerson, DayRepDataForCalendarViewModel> _mapper;

        public DayRepDataForCalendarQueryHandler(IUnitOfWork unitOfWork, 
            IMapperWithParams<DayRepGroupPerson, DayRepDataForCalendarViewModel> mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DayRepDataForCalendarViewModel>> HandleAsync(DayRepDataForCalendarQuery query)
        {
            var tmp = await _unitOfWork.Repository<DayRepGroupPerson>()
                .FindAllWithIncludesAsync(x => x.GroupForDayRepId == query.DayRepGroupId,
                    includes: i => i.Include(x => x.DayReps));

            return tmp.Select(x => _mapper.MapObject(x, query.StartDate, query.EndDate)).ToList();
        }
    }
}
