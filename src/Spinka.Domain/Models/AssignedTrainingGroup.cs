namespace Spinka.Domain.Models
{
    public class AssignedTrainingGroup : BaseEntity
    {
        public virtual TrainingGroup TrainingGroup { get; set; }
        public int TrainingGroupId { get; set; }
        public virtual EduBlock EduBlock { get; set; }
        public int EduBlockId { get; set; }
    }
}