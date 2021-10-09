using System.Threading.Tasks;

namespace Spinka.Application.Dispatchers.Commands
{
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        Task HandleAsync(TCommand command);
    }
}