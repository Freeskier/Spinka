using Spinka.Application.Dispatchers.Commands;

namespace Spinka.Application.TrainingGroupsPerson.Commands
{
    public class AddPersonToGroup : ICommand
    {
        public int PersonId { get; set; }
        public int TrainingGroupId { get; set; }

        public AddPersonToGroup() { }

        public AddPersonToGroup(int personId, int trainingGroupId)
        {
            PersonId = personId;
            TrainingGroupId = trainingGroupId;
        }
    }
}