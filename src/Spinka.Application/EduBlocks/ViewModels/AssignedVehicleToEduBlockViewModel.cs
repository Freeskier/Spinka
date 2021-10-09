namespace Spinka.Application.EduBlocks.ViewModels
{
    public class AssignedVehicleToEduBlockViewModel
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string RegisterNumber { get; set; }
        public string VehicleType { get; set; }
        public string Name => $"{Brand} {Model} {RegisterNumber}";
    }
}