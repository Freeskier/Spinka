using System;
using System.Collections.Generic;

namespace Spinka.Domain.Models
{
    public class CurrentAmmoLimitsForDepartment : BaseEntity
    {
        public int Quantity { get; set; }
        public DateTime ActualizationDate { get; set; }

        public virtual UnitDepartment UnitDepartment { get; set; }
        public int? UnitDepartmentsId { get; set; }

        public virtual Ammo Ammo { get; set; }
        public int? AmmoId { get; set; }

        private ISet<AmmoTransaction> _ammoTransactions = new HashSet<AmmoTransaction>();
        public IEnumerable<AmmoTransaction> AmmoTransactions => _ammoTransactions;
    }
}