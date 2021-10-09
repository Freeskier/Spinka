using System.Collections.Generic;

namespace Spinka.Application.UnitDepartments.ViewModels
{
    public class UnitDepartmentWithAmmoDetailViewModel : UnitDepartmentViewModel
    {
        public IEnumerable<AmmoDetailToDepartmentViewModel> Limits { get; set; }

        // public UnitDepartmentWithAmmoDetailViewModel()
        // {
        //     Limits = new List<AmmoDetailToDepartmentViewModel>();
        // }
    }
}