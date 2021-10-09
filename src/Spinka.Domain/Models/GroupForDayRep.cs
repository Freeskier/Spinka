using System.Collections.Generic;

namespace Spinka.Domain.Models
{
    public class GroupForDayRep : BaseEntity
    {
        public string Name { get; set; }
        public virtual UnitDepartment UnitDepartment { get; set; }
        public int UnitDepartmentsId { get; set; }
        private ISet<DayRepGroupPerson> _dayRepGroupPersons = new HashSet<DayRepGroupPerson>();
        public IEnumerable<DayRepGroupPerson> DayRepGroupPersons => _dayRepGroupPersons;
    }
}