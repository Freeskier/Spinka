using Spinka.Application.Dispatchers.Commands;

namespace Spinka.Application.GroupForDayReps.Commands
{
    public class AddPersonToGroupForDayRepCommand :ICommand
    {
        public int PersonId { get; set; }
        public int GroupId { get; set; }
        public bool IsDelegated { get; set; }

        public AddPersonToGroupForDayRepCommand()
        {
                
        } 
        public AddPersonToGroupForDayRepCommand(int personId, int groupId, bool isDelegated)
        {
            PersonId = personId;
            GroupId = groupId;
            IsDelegated = isDelegated;
        }

    }
}
