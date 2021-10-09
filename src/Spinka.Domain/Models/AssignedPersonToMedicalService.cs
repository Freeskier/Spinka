namespace Spinka.Domain.Models
{
    public class AssignedPersonToMedicalService : BaseEntity
    {
        public virtual Person Person { get; set; }
        public int PersonId { get; set; }
        public virtual MedicalServiceForEduBlock MedicalServiceForEduBlock { get; set; }
        public int MedicalServiceForEduBlockId { get; set; }
    }
}