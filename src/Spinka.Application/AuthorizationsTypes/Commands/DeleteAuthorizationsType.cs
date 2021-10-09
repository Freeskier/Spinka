using Spinka.Application.Dispatchers.Commands;

namespace Spinka.Application.AuthorizationsTypes.Commands
{
    public class DeleteAuthorizationsType : ICommand
    {
        public int AuthorizationsTypeId { get; set; }
    }
}