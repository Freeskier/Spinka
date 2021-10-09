using Spinka.Application.Dispatchers.Commands;

namespace Spinka.Application.GroupForDayReps.Commands
{
    public class DeletePersonFromGroupCommand : ICommand
    {
        public int PersonInGroupId { get; set; }

    }

}
