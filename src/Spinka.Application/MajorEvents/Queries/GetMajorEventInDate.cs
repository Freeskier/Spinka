using System;
using System.Collections.Generic;
using Spinka.Application.Dispatchers.Queries;
using Spinka.Application.MajorEvents.ViewModels;

namespace Spinka.Application.MajorEvents.Queries
{
    public class GetMajorEventInDate : IQuery<IEnumerable<MajorEventViewModel>>
    {
        public DateTime Date { get; set; }
    }
}