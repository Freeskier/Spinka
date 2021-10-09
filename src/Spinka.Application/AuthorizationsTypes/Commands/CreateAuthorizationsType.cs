using Spinka.Application.Dispatchers.Commands;

namespace Spinka.Application.AuthorizationsTypes.Commands
{
    public class CreateAuthorizationsType : ICommand
    {
        public string AuthorizationsTypeName { get; set; }
    }
}