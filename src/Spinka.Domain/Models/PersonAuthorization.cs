namespace Spinka.Domain.Models
{
    public class PersonAuthorization : BaseEntity
    {
        public virtual AuthorizationsType AuthorizationsType { get; set; }
        public int AuthorizationTypeId { get; set; }
        public virtual Person Person { get; set; }
        public int PersonId { get; set; }
    }
}