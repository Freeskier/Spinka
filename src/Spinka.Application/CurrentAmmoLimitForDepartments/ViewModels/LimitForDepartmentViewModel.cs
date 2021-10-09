namespace Spinka.Application.CurrentAmmoLimitForDepartments.ViewModels
{
    public class LimitForDepartmentViewModel 
    {
        public int Id { get; set; }
        public int AmmoId { get; set; }
        public string Ammo { get; set; }
        public int Quantity { get; set; }
        public string Measure { get; set; }
        public string DisplayName => $"{Ammo} {Quantity} {Measure}";
    }
}