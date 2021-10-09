using Spinka.Application.Dispatchers.Queries;
using Spinka.Application.EduBlocks.ViewModels;

namespace Spinka.Application.EduBlocks.Queries
{
    public class GetEduBlock : IQuery<EduBlockDetailViewModel>
    {
        public int Id { get; set; }
    }
}