using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Spinka.Application.Dispatchers.Commands
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public CommandDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        
        public async Task SendAsync<TCommand>(TCommand command) where TCommand : ICommand
        {
            var service = _serviceProvider.GetRequiredService<ICommandHandler<TCommand>>();
            
            await service.HandleAsync(command);  
        }
    }
}