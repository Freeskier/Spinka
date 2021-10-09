using Spinka.Application.Dispatchers.Commands;

namespace Spinka.Application.Persons.Commands
{
    public class AddPersonAuthorizationsType : ICommand
    {
        public int PersonId { get; set; }
        public int AuthorizationsTypeId { get; set; }
    }
}