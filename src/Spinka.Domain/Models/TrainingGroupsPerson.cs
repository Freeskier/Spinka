namespace Spinka.Domain.Models
{
    public class TrainingGroupsPerson : BaseEntity
    {
        public virtual Person Person { get; set; }
        public int PersonId { get; set; }

        public virtual TrainingGroup TrainingGroup { get; set; }
        public int TrainingGroupId { get; set; }
    }
}