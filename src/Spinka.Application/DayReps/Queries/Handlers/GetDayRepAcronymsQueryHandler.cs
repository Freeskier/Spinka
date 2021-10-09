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
    public class GetDayRepAcronymsQueryHandler : IQueryHandler<GetDayRepAcronyms, IEnumerable<DayRepAcronymViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper<DayRepAcronym, DayRepAcronymViewModel> _mapper;

        public GetDayRepAcronymsQueryHandler(IUnitOfWork unitOfWork, IMapper<DayRepAcronym, DayRepAcronymViewModel> mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        public async Task<IEnumerable<DayRepAcronymViewModel>> HandleAsync(GetDayRepAcronyms query)
        {
            var dayRepAccronyms = await _unitOfWork.Repository<DayRepAcronym>().GetAllAsync();

            return dayRepAccronyms.Select(_mapper.MapObject);
        }
    }
}
