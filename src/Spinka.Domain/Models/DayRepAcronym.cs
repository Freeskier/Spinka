using System.Collections.Generic;

namespace Spinka.Domain.Models
{
    public class DayRepAcronym : BaseEntity 
    {
        public string Name { get; set; } 
        public string Description { get; set; }
        public string Color { get; set; }

        private ISet<DayRep> _dayReps = new HashSet<DayRep>();
        public IEnumerable<DayRep> DayReps => _dayReps;
    }
}