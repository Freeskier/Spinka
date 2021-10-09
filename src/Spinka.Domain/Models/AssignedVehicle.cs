namespace Spinka.Domain.Models
{
    public class AssignedVehicle : BaseEntity
    {
        public virtual EduBlock EduBlock { get; set; }
        public int EduBlockId { get; set; }

        public virtual Vehicle Vehicle { get; set; }
        public int  VehicleId { get; set; }
    }
}