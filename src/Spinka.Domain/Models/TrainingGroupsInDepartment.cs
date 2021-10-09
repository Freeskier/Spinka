namespace Spinka.Domain.Models
{
    public class TrainingGroupsInDepartment : BaseEntity
    {
        public virtual TrainingGroup TrainingGroup { get; set; }
        public int TrainingGroupId { get; set; }

        public virtual UnitDepartment UnitDepartment { get; set; }
        public int UnitDepartmentsId { get; set; }
    }
}