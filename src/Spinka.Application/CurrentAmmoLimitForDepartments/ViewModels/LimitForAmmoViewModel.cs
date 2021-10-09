namespace Spinka.Application.CurrentAmmoLimitForDepartments.ViewModels
{
    public class LimitForAmmoViewModel
    {
        public int Id { get; set; }
        public int UnitDepartmentId { get; set; }
        public string UnitDepartment { get; set; }
        public int Quantity { get; set; }
        public string Measure { get; set; }
    }
}