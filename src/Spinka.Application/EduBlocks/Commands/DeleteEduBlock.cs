using Spinka.Application.Dispatchers.Commands;

namespace Spinka.Application.EduBlocks.Commands
{
    public class DeleteEduBlock : ICommand
    {
        public int Id { get; set; }
        public string CancellingRemarks { get; set; }
    }
}