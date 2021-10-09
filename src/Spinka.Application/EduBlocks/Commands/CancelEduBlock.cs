using Spinka.Application.Dispatchers.Commands;

namespace Spinka.Application.EduBlocks.Commands
{
    public class CancelEduBlock : ICommand
    {
        public int Id { get; set; }
        public string CancellReason { get; set; }
    }
}