using Spinka.Application.Dispatchers.Queries;
using Spinka.Application.EduBlocks.ViewModels;

namespace Spinka.Application.EduBlocks.Queries
{
    public class GetMajorEventAssignedToEduBlock : IQuery<MajorEventAssignedToEduBlockViewModel>
    {
        public int EduBlockId { get; set; }
    }
}