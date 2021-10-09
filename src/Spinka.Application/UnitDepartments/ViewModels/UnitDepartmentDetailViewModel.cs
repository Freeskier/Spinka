using System.Collections.Generic;

namespace Spinka.Application.UnitDepartments.ViewModels
{
    public class UnitDepartmentDetailViewModel : UnitDepartmentViewModel
    {
        public IEnumerable<CurrentLimitViewModel> Limits { get; set; }

        // public UnitDepartmentDetailViewModel()
        // {
        //     Limits = new List<CurrentLimitViewModel>();
        // }
    }
}