namespace Spinka.Application.Ammo.ViewModels
{
    public class AmmoDetailViewModel : AmmoViewModel
    {
        public int Quantity { get; set; }
        public string UnitDepartment { get; set; }
        public string TrainingGroup { get; set; }
        public string DisplayName { get; set; }
    }
}