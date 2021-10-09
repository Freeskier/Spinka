using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Spinka.Application.Dispatchers.Queries;
using Spinka.Application.Extensions;
using Spinka.Application.TrainingLogs.ViewModels;
using Spinka.Domain.Models;
using Spinka.Domain.Repositories;
using Spinka.Infrastructure.Mappers;

namespace Spinka.Application.TrainingLogs.Queries.Handlers
{
    public class GetTrainingLogsByGroupIdQueryHandler : IQueryHandler<GetTrainingLogsByGroupId, IEnumerable<TrainingLogByGroupIdViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper<EduBlock, TrainingLogByGroupIdViewModel> _mapper;

        public GetTrainingLogsByGroupIdQueryHandler(IUnitOfWork  unitOfWork, 
            IMapper<EduBlock, TrainingLogByGroupIdViewModel> mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
    
        public async Task<IEnumerable<TrainingLogByGroupIdViewModel>> HandleAsync(GetTrainingLogsByGroupId query)
        {
            var eduBlocks = await _unitOfWork.Repository<AssignedTrainingGroup>()
                .FindAllWithIncludesAsync(x => x.TrainingGroupId == query.GroupId,
                    i => i.Include(q => q.EduBlock))
                .SelectAsync(x => x.Select(y => y.EduBlock)
                    .Where(z => !z.IsDeleted && z.StartTime >= query.DateFrom && z.EndOn <= query.DateTo));
            
            return eduBlocks.Select(_mapper.MapObject);
        }
    }
}