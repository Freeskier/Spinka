using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Spinka.Application.Dispatchers.Queries;
using Spinka.Application.Extensions;
using Spinka.Application.TrainingGroups.ViewModels;
using Spinka.Domain.Models;
using Spinka.Domain.Repositories;
using Spinka.Infrastructure.Mappers;

namespace Spinka.Application.TrainingGroups.Queries.Handlers
{
    public class GetTrainingGroupsInDepartmentQueryHandler : IQueryHandler<GetTrainingGroupsInDepartment, IEnumerable<TrainingGroupsInDepartmentViewModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper<TrainingGroupsInDepartment, TrainingGroupsInDepartmentViewModel> _mapper;

        public GetTrainingGroupsInDepartmentQueryHandler(IUnitOfWork unitOfWork, IMapper<TrainingGroupsInDepartment, TrainingGroupsInDepartmentViewModel> mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TrainingGroupsInDepartmentViewModel>> HandleAsync(GetTrainingGroupsInDepartment query)
        {
            var trainingGroups = await _unitOfWork.Repository<TrainingGroupsInDepartment>().FindAllWithIncludesAsync(
                x => x.UnitDepartmentsId == query.DepartmentId && !x.IsDeleted,
                i => i.Include(x => x.TrainingGroup));
            return trainingGroups.Select(_mapper.MapObject);
        }
    }
}