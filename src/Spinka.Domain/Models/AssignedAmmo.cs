namespace Spinka.Domain.Models
{
    public class AssignedAmmo : BaseEntity
    {
        public virtual Ammo Ammo { get; set; }
        public int AmmoId { get; set; }
        public virtual EduBlock EduBlock { get; set; }
        public int EduBlockId { get; set; }
        public int Quantity { get; set; }
    }
}