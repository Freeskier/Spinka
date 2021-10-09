using System.Collections.Generic;

namespace Spinka.Domain.Models
{
    public class DayRepGroupPerson : BaseEntity
    {
        public virtual GroupForDayRep GroupForDayRep { get; set; }
        public int GroupForDayRepId { get; set; }
        public bool IsDelegated { get; set; }
        public virtual Person Person { get; set; }
        public int PersonId { get; set; }
        private ISet<DayRep> _dayReps = new HashSet<DayRep>();
        public IEnumerable<DayRep> DayReps => _dayReps;
    }
}