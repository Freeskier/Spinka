using System;

namespace Spinka.Domain.Models
{
    public class PersonAuthorisedForEduBlockFunction : BaseEntity
    {
        public AuthorizationsType AuthorizationsType { get; set; }
        public int AuthorisationsTypeId { get; set; }
        public Person Person { get; set; }
        public int PersonId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndOn { get; set; }
    }
}