using System.Threading.Tasks;

namespace Spinka.Application.Dispatchers.Commands
{
    public interface ICommandDispatcher
    {
        Task SendAsync<TCommand>(TCommand command) where TCommand : ICommand;
    }
}