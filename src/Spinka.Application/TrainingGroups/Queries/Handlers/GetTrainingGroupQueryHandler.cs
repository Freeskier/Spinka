using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Spinka.Application.Dispatchers.Queries;
using Spinka.Application.Extensions;
using Spinka.Application.TrainingGroups.ViewModels;
using Spinka.Domain.Repositories;
using Spinka.Infrastructure.Mappers;
using TrainingGroupEntity =  Spinka.Domain.Models.TrainingGroup;

namespace Spinka.Application.TrainingGroups.Queries.Handlers
{
    // THING ABOUT THIS -> MAY REMOVE!!!
    public class GetTrainingGroupQueryHandler : IQueryHandler<GetTrainingGroup, TrainingGroupDetailViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper<TrainingGroupEntity, TrainingGroupDetailViewModel> _mapper;

        public GetTrainingGroupQueryHandler(IUnitOfWork unitOfWork, IMapper<TrainingGroupEntity, TrainingGroupDetailViewModel> mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        
        public async Task<TrainingGroupDetailViewModel> HandleAsync(GetTrainingGroup query)
        {
            var trainingGroup = await _unitOfWork.Repository<TrainingGroupEntity>()
                .GetOrFailWithIncludesAsync(x => x.Id == query.Id, 
                includes: i => i.Include(x => x.AssignedTrainingGroups)
                    .Include(x => x.TrainingGroupsPersons)
                    .Include(x => x.TrainingGroupsInDepartments));
            
            return _mapper.MapObject(trainingGroup);
        }
    }
}