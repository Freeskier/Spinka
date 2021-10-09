using System.Collections.Generic;

namespace Spinka.Domain.Models
{
    public class TrainingGroup : BaseEntity
    {
        public string Name { get; set; }

        private ISet<TrainingGroupsPerson> _trainingGroupsPersons = new HashSet<TrainingGroupsPerson>();
        public IEnumerable<TrainingGroupsPerson> TrainingGroupsPersons => _trainingGroupsPersons;

        private ISet<AssignedTrainingGroup> _assignedTrainingGroups = new HashSet<AssignedTrainingGroup>();
        public IEnumerable<AssignedTrainingGroup> AssignedTrainingGroups => _assignedTrainingGroups;

        private ISet<TrainingGroupsInDepartment> _trainingGroupsInDepartments = new HashSet<TrainingGroupsInDepartment>();
        public IEnumerable<TrainingGroupsInDepartment> TrainingGroupsInDepartments => _trainingGroupsInDepartments;
    }
}