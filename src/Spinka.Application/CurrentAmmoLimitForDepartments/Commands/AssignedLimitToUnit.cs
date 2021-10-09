using System.Collections.Generic;
using Spinka.Application.CurrentAmmoLimitForDepartments.ViewModels;
using Spinka.Application.Dispatchers.Commands;

namespace Spinka.Application.CurrentAmmoLimitForDepartments.Commands
{
    public class AssignedLimitToUnit : ICommand
    {
         public int UnitDepartmentId { get; set; }
         public IEnumerable<ChangeAmmoLimitViewModel> Ammo { get; set; }
        
         public AssignedLimitToUnit() { }
                
         public AssignedLimitToUnit(int unitDepartmentId, IEnumerable<ChangeAmmoLimitViewModel> ammo)
         {
             UnitDepartmentId = unitDepartmentId;
             Ammo = ammo;
         }
    }
}