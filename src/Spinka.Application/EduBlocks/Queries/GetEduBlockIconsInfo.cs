using Spinka.Application.Dispatchers.Queries;
using Spinka.Application.EduBlocks.ViewModels;

namespace Spinka.Application.EduBlocks.Queries
{
    public class GetEduBlockIconsInfo : IQuery<IconsInfoViewModel>
    {
        public int EduBlockId { get; set; }

        public GetEduBlockIconsInfo(int id)
        {
            EduBlockId = id;
        }
    }
}