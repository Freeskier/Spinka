using System.Collections.Generic;
using Spinka.Application.Dispatchers.Queries;
using Spinka.Application.UnitDepartments.ViewModels;

namespace Spinka.Application.UnitDepartments.Queries
{
    public class GetUnitDepartmentsWithAmmo : IQuery<IEnumerable<UnitDepartmentWithAmmoDetailViewModel>> { }
}