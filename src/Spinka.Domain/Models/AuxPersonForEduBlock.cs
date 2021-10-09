namespace Spinka.Domain.Models
{
    public class AuxPersonForEduBlock : BaseEntity
    {
        public virtual EduBlock EduBlock { get; set; }
        public int EduBlockId { get; set; }
        public virtual Person Person{ get; set; }
        public int PersonId { get; set; }
    }
}