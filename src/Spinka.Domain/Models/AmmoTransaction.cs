using System;

namespace Spinka.Domain.Models
{
    public class AmmoTransaction : BaseEntity
    {
        public int Quantity { get; set; }
        public int AmmoAdminId { get; set; }
        public DateTime TransactionDateTime { get; set; }
        public string Remarks { get; set; } 

        public virtual AmmoTransactionType AmmoTransactionType { get; set; }
        public int? AmmoTransactionTypeId { get; set; }

        public virtual CurrentAmmoLimitsForDepartment CurrentAmmoLimitsForDepartment { get; set; }
        public int? CurrentAmmoLimitsForDepartmentId { get; set; }
    }   
}