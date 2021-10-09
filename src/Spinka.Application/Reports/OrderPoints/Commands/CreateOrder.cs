using Spinka.Application.Dispatchers.Commands;

namespace Spinka.Application.Reports.OrderPoints.Commands
{
    public class CreateOrder : ICommand
    {
        public int EduBlockId { get; set; }

        public CreateOrder() { }

        public CreateOrder(int eduBlockId)
        {
            EduBlockId = eduBlockId;
        }
    }
}