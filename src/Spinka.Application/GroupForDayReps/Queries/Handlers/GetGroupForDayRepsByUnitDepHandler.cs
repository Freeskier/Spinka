using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Spinka.Application.Dispatchers.Queries;
using Spinka.Application.GroupForDayReps.ViewModels;
using Spinka.Domain.Models;
using Spinka.Domain.Repositories;
using Spinka.Infrastructure.Mappers;

namespace Spinka.Application.GroupForDayReps.Queries.Handlers
{
    public class GetGroupForDayRepsByUnitDepHandler : IQueryHandler<GetGroupForDayRepsByUnitDep, IEnumerable<GetGroupForDayRepByUnitDepViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper<GroupForDayRep, GetGroupForDayRepByUnitDepViewModel> _mapper;

        public GetGroupForDayRepsByUnitDepHandler(IUnitOfWork unitOfWork, IMapper<GroupForDayRep, GetGroupForDayRepByUnitDepViewModel> mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public GetGroupForDayRepsByUnitDepHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<GetGroupForDayRepByUnitDepViewModel>> HandleAsync(GetGroupForDayRepsByUnitDep query)
        {
            var groups = await _unitOfWork.Repository<GroupForDayRep>()
                .FindAllAsync(x => x.UnitDepartmentsId == query.UnitDepId && !x.IsDeleted);
            return groups.Select(_mapper.MapObject);
        }
    }
}