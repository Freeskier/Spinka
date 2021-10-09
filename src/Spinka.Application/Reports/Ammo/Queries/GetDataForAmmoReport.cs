using System;
using Spinka.Application.Dispatchers.Queries;
using Spinka.Application.Reports.Ammo.ViewModels;

namespace Spinka.Application.Reports.Ammo.Queries
{
    public class GetDataForAmmoReport : IQuery<AmmoReportViewModel>
    {
        public int EduBlockId { get; set; }
        public string OrderNumber { get; set; }
        public DateTime OrderDate { get; set; }
    }
}