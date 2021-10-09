using System.Linq;
using Spinka.Application.TrainingGroups.ViewModels;
using Spinka.Application.Utils.Helpers;
using Spinka.Domain.Models;
using Spinka.Domain.Repositories;
using Spinka.Infrastructure.Mappers;
using TrainingGroupEntity =  Spinka.Domain.Models.TrainingGroup;

namespace Spinka.Application.TrainingGroups.Mappers
{
    public class TrainingGroupDetailMapper : IMapper<TrainingGroupEntity, TrainingGroupDetailViewModel>
    {
        private readonly IUnitOfWork _unitOfWork;

        public TrainingGroupDetailMapper(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        
        public TrainingGroupDetailViewModel MapObject(TrainingGroupEntity entity)
        {
            return new TrainingGroupDetailViewModel
            {
                Id = entity.Id,
                Name = entity.Name,
                TrainingGroupInDepartmentsCount = entity.TrainingGroupsInDepartments.Count(),
                EduBlocksCount = entity.AssignedTrainingGroups.Count(),
                EduBlocks = entity.AssignedTrainingGroups.Select(x => new AssignedTrainingGroupViewModel
                {
                    Id = x.Id,
                    EduBlockId = x.EduBlockId,
                    EduBlock = MapperHelper.HelpWithGetTrainingGroupDetailsToEduBlock(x.EduBlockId, _unitOfWork),
                    StartTime = _unitOfWork.Repository<EduBlock>()
                        .FindByAsync(p => p.Id == x.EduBlockId)
                        .GetAwaiter()
                        .GetResult().StartTime,
                    EndTime = _unitOfWork.Repository<EduBlock>()
                        .FindByAsync(p => p.Id == x.EduBlockId)
                        .GetAwaiter()
                        .GetResult().EndOn
                }),
                TrainingGroupsPersons = entity.TrainingGroupsPersons.Select(x => new TrainingGroupsPersonViewModel
                {
                    Id = x.Id,
                    PersonId = x.PersonId,
                    TrainingGroupId = x.TrainingGroupId,
                }),
                TrainingGroupInDepartments = entity.TrainingGroupsInDepartments.Select(x => new TrainingGroupInDepartmentsViewModel
                {
                    Id = x.Id,
                    TrainingGroupId = x.TrainingGroupId,
                    UnitDepartmentsId = x.UnitDepartmentsId
                })
            };
        }
    }
}