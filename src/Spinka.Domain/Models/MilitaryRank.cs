using System.Collections.Generic;

namespace Spinka.Domain.Models
{
    public class MilitaryRank : BaseEntity
    {
        public string FullRankPl { get; set; }
        public string FullRankEn { get; set; }
        public string Nato { get; set; }
        public int Grading { get; set; }
        public string AcrRankPl { get; set; }
        public string AcrRankEn { get; set; }
        private ISet<Person> _persons = new HashSet<Person>();
        public IEnumerable<Person> Persons => _persons;
    }
}