using Spinka.Application.Dispatchers.Commands;

namespace Spinka.Application.EduBlocks.Commands
{
    public class ApproveEduBlock : ICommand
    {
        public int Id { get; set; }

        public ApproveEduBlock() { }

        public ApproveEduBlock(int id)
        {
            Id = id;
        }
    }
}