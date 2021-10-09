using Spinka.Application.TrainingGroups.ViewModels;
using Spinka.Domain.Models;
using Spinka.Infrastructure.Mappers;

namespace Spinka.Application.TrainingGroups.Mappers
{
    public class TrainingGroupsInDepartmentMapper : IMapper<TrainingGroupsInDepartment, TrainingGroupsInDepartmentViewModel>
    {
        public TrainingGroupsInDepartmentViewModel MapObject(TrainingGroupsInDepartment entity)
        {
            var trainingGroup = new TrainingGroupsInDepartmentViewModel
            {
                TrainingGroupId = entity.TrainingGroupId,
                TrainingGroupName = entity.TrainingGroup.Name
            };
            return trainingGroup;
        }
    }
}