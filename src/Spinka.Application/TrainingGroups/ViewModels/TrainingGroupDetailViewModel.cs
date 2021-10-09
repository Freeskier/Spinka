using System.Collections.Generic;

namespace Spinka.Application.TrainingGroups.ViewModels
{
    public class TrainingGroupDetailViewModel : TrainingGroupViewModel
    {
        public int TrainingGroupInDepartmentsCount { get; set; }
        public int EduBlocksCount { get; set; }
        public IEnumerable<TrainingGroupsPersonViewModel> TrainingGroupsPersons { get; set; }
        public IEnumerable<TrainingGroupInDepartmentsViewModel> TrainingGroupInDepartments { get; set; }
        public IEnumerable<AssignedTrainingGroupViewModel> EduBlocks { get; set; }
    }
}