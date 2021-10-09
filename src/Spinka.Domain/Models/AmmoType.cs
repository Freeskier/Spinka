using System.Collections.Generic;
//Enum???
namespace Spinka.Domain.Models
{
    public class AmmoType : BaseEntity
    {
        public string Name { get; set; }

        private ISet<Ammo> _ammo = new HashSet<Ammo>();
        public IEnumerable<Ammo> Ammo => _ammo;
    }
}