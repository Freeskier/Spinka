using System.Collections.Generic;
using Spinka.Application.CurrentAmmoLimitForDepartments.ViewModels;
using Spinka.Application.Dispatchers.Queries;

namespace Spinka.Application.CurrentAmmoLimitForDepartments.Queries
{
    public class GetAmmoLimitsForDepartment : IQuery<IEnumerable<LimitForDepartmentViewModel>>
    {
        public int UnitDepartmentId { get; set; }
    }
}