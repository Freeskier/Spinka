namespace Spinka.Application.CurrentAmmoLimitForDepartments.ViewModels
{
    public class ChangeAmmoLimitViewModel
    {
        public int AmmoTransactionTypeId { get; set; }
        public string Remarks { get; set; }
        public int AmmoId { get; set; }
        public int Amount { get; set; }
    }
}