using System;
using System.Collections.Generic;
using Spinka.Application.Dispatchers.Queries;
using Spinka.Application.EduBlocksHistory.ViewModels;

namespace Spinka.Application.EduBlocksHistory.Queries 
{
    public class GetEduBlockHistoryByGuid : IQuery<IEnumerable<EduBlockHistoryViewModel>>
    {
        public Guid EduBlockHistoryGuid { get; set; }
    }
}