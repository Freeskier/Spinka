using System.Collections.Generic;

namespace Spinka.Domain.Models
{
    public class MeasureUnit : BaseEntity
    {
        public string Name { get; set; }
        public string Acronym { get; set; }

        private ISet<Ammo> _ammo = new HashSet<Ammo>();
        public IEnumerable<Ammo> Ammo => _ammo;
    }
}