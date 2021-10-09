using System;
using Spinka.Application.Dispatchers.Commands;

namespace Spinka.Application.Reports.Ammo.Commands
{
    public class CreateAmmoReport : ICommand
    {
        public int EduBlockId { get; set; }
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
    }
}