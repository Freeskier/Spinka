using Spinka.Application.Dispatchers.Queries;
using Spinka.Application.UnitDepartments.ViewModels;

namespace Spinka.Application.UnitDepartments.Queries
{
    public class GetUnitDepartment : IQuery<UnitDepartmentDetailViewModel>
    {
        public int Id { get; set; }
    }
}