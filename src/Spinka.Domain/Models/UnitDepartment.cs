using System.Collections.Generic;

namespace Spinka.Domain.Models
{
    public class UnitDepartment : BaseEntity
    {
        public string Name { get; set; }
        private ISet<MajorEvent> _majorEvents = new HashSet<MajorEvent>();
        public IEnumerable<MajorEvent> MajorEvents => _majorEvents;

        private ISet<TrainingGroupsInDepartment> _trainingGroupsInDepartments = new HashSet<TrainingGroupsInDepartment>();
        public IEnumerable<TrainingGroupsInDepartment> TrainingGroupsInDepartments => _trainingGroupsInDepartments;

        private ISet<CurrentAmmoLimitsForDepartment> _currentAmmoLimitsForDepartments = new HashSet<CurrentAmmoLimitsForDepartment>();
        public IEnumerable<CurrentAmmoLimitsForDepartment> CurrentAmmoLimitsForDepartments => _currentAmmoLimitsForDepartments;
        private ISet<GroupForDayRep> _groupForDayReps = new HashSet<GroupForDayRep>();
        public IEnumerable<GroupForDayRep> GroupForDayReps => _groupForDayReps;
    }
}