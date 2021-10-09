using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Spinka.Application.Dispatchers.Queries;
using Spinka.Application.EduBlocksHistory.ViewModels;
using Spinka.Domain.Models;
using Spinka.Domain.Repositories;
using Spinka.Infrastructure.Mappers;

namespace Spinka.Application.EduBlocksHistory.Queries.Handlers
{
    public class GetEduBlockByGuidQueryHandler : IQueryHandler<GetEduBlockHistoryByGuid, IEnumerable<EduBlockHistoryViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper<EduBlockHistory, EduBlockHistoryViewModel> _mapper;

        public GetEduBlockByGuidQueryHandler(IUnitOfWork unitOfWork, IMapper<EduBlockHistory, EduBlockHistoryViewModel> mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<EduBlockHistoryViewModel>> HandleAsync(GetEduBlockHistoryByGuid query)
        {
            var eduBlockHistory = await _unitOfWork.Repository<EduBlockHistory>().FindAllAsync(
                x => x.ModifyGuid == query.EduBlockHistoryGuid);
            return eduBlockHistory.Select(_mapper.MapObject).ToList();
        }
    }
}