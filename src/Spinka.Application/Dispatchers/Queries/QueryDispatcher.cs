using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace Spinka.Application.Dispatchers.Queries
{
    public class QueryDispatcher : IQueryDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public QueryDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        
        public async Task<TResult> QueryAsync<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>
        {
            var service = _serviceProvider.GetRequiredService<IQueryHandler<TQuery, TResult>>();
            
            return await service.HandleAsync(query);
        }
    }
}