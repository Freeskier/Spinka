using System.Collections.Generic;
using Spinka.Application.CurrentAmmoLimitForDepartments.ViewModels;
using Spinka.Application.Dispatchers.Commands;

namespace Spinka.Application.CurrentAmmoLimitForDepartments.Commands
{
    public class UpdateLimit : ICommand
    {
        public int UnitDepartmentId { get; set; }
        public int? ShiftUnitDepartmentId { get; set; }
        public IEnumerable<ChangeAmmoLimitViewModel> Ammo { get; set; }

        public UpdateLimit() { }
        
        public UpdateLimit(int unitDepartmentId, IEnumerable<ChangeAmmoLimitViewModel> ammo)
        {
            UnitDepartmentId = unitDepartmentId;
            Ammo = ammo;
        }
    }
}