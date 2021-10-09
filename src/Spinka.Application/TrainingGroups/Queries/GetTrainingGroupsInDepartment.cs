using System.Collections.Generic;
using Spinka.Application.Dispatchers.Queries;
using Spinka.Application.TrainingGroups.ViewModels;

namespace Spinka.Application.TrainingGroups.Queries
{
    public class GetTrainingGroupsInDepartment : IQuery<IEnumerable<TrainingGroupsInDepartmentViewModel>>
    {
        public int DepartmentId { get; set; } 
    }
}