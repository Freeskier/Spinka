using Spinka.Application.Dispatchers.Queries;
using Spinka.Application.GroupForDayReps.ViewModels;
using Spinka.Domain.Models;
using Spinka.Domain.Repositories;
using Spinka.Infrastructure.Mappers;
using System.Threading.Tasks;


namespace Spinka.Application.GroupForDayReps.Queries.Handlers
{
    public class GetGroupForDayRepHandler : IQueryHandler<GetGroupForDayRepQuery, GetGroupForDayRepViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper<GroupForDayRep, GetGroupForDayRepViewModel> _mapper;
        public GetGroupForDayRepHandler(IUnitOfWork unitOfWork, IMapper<GroupForDayRep, GetGroupForDayRepViewModel> mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<GetGroupForDayRepViewModel> HandleAsync(GetGroupForDayRepQuery query)
        {
            // REFACTOR TO DAPPER!!!
            var result = await _unitOfWork.Repository<GroupForDayRep>()
                        .FindByIdAsync(query.DayRepGroupId);
            return _mapper.MapObject(result);
        }
    }
}
