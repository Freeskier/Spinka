using Spinka.Application.Dispatchers.Commands;

namespace Spinka.Application.Persons.Commands
{
    public class DeletePersonAuthorizationsType : ICommand 
    {
        public int PersonAuthorizationsId { get; set; }
    }
}