namespace Spinka.Domain.Models
{
    public class AdditionalPersonnel : BaseEntity
    {
        public virtual Person Person { get; set; }
        public int PersonId { get; set; }
        public virtual EduBlock EduBlock { get; set; }
        public int EduBlockId { get; set; }
        public bool IsLivePlayer { get; set; }
    }
}