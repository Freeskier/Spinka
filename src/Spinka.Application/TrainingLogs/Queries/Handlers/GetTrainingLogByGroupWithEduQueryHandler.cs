using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Spinka.Application.Dispatchers.Queries;
using Spinka.Application.Extensions;
using Spinka.Application.TrainingLogs.ViewModels;
using Spinka.Domain.Models;
using Spinka.Domain.Repositories;
using Spinka.Infrastructure.Mappers;

namespace Spinka.Application.TrainingLogs.Queries.Handlers
{
    public class GetTrainingLogByGroupWithEduQueryHandler : IQueryHandler<GetTrainingLogByGroupWithEdu, IEnumerable<TrainingLogByGroupWithEduViewModel>>
    {
        public GetTrainingLogByGroupWithEduQueryHandler(IUnitOfWork unitOfWork, IMapper<AssignedTrainingFacility, TrainingLogByGroupWithEduViewModel> mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper<AssignedTrainingFacility, TrainingLogByGroupWithEduViewModel> _mapper;

        public async Task<IEnumerable<TrainingLogByGroupWithEduViewModel>> HandleAsync(GetTrainingLogByGroupWithEdu query)
        {
            var assignedTrainingFacilities = await _unitOfWork.Repository<AssignedTrainingGroup>()
                .FindAllWithIncludesAsync(x => x.TrainingGroupId == query.GroupId,
                    i => i.Include(e => e.EduBlock.EduBlockSubject.TrainingArea)
                        .Include(q => q.EduBlock)
                        .ThenInclude(r => r.AssignedTrainingFacilities).ThenInclude(t => t.TrainingFacility))
                .SelectAsync(x => x.Select(y => y.EduBlock).SelectMany(t => t.AssignedTrainingFacilities)
                    .Where(z => !z.IsDeleted && z.StartTime >= query.DateFrom && z.EndOn <= query.DateTo));

            return assignedTrainingFacilities.Select(_mapper.MapObject);
        }
    }
}