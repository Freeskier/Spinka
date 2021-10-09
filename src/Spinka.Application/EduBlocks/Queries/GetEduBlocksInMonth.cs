using System.Collections.Generic;
using Spinka.Application.Dispatchers.Queries;
using Spinka.Application.EduBlocks.ViewModels;

namespace Spinka.Application.EduBlocks.Queries
{
    public class GetEduBlocksInMonth : IQuery<IEnumerable<EduBlockToApproveViewModel>>
    {
        public int MonthNumber { get; set; }
    }
}