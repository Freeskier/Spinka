using System.Collections.Generic;

namespace Spinka.Domain.Models
{
    public class Ammo : BaseEntity
    {
        public string Name { get; set; }
        public string LogIndex { get; set; }
        public bool IsDangerous { get; set; }

        private ISet<CurrentAmmoLimitsForDepartment> _currentAmmoLimitsForDepartments = new HashSet<CurrentAmmoLimitsForDepartment>();
        public IEnumerable<CurrentAmmoLimitsForDepartment> CurrentAmmoLimitsForDepartments => _currentAmmoLimitsForDepartments;
        
        private ISet<AssignedAmmo> _assignedAmmo = new HashSet<AssignedAmmo>();
        public IEnumerable<AssignedAmmo> AssignedAmmo => _assignedAmmo;

        public virtual MeasureUnit MeasureUnit { get; set; }
        public int MeasureUnitId { get; set; }

        public virtual AmmoType AmmoType { get; set; }
        public int AmmoTypeId { get; set; }
    }
}