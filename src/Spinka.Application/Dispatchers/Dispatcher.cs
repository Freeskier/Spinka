using System.Threading.Tasks;
using Spinka.Application.Dispatchers.Commands;
using Spinka.Application.Dispatchers.Queries;

namespace Spinka.Application.Dispatchers
{
    public class Dispatcher : IDispatcher
    {
        private readonly ICommandDispatcher _commandDispatcher;
        private readonly IQueryDispatcher _queryDispatcher;

        public Dispatcher(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
        {
            _commandDispatcher = commandDispatcher;
            _queryDispatcher = queryDispatcher;
        }
        
        public async Task SendAsync<TCommand>(TCommand command) where TCommand : ICommand
        {
            await _commandDispatcher.SendAsync(command);
        }

        public async Task<TResult> QueryAsync<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>
        {
            return await _queryDispatcher.QueryAsync<TQuery, TResult>(query);
        }
    }
}