using System.Threading.Tasks;

namespace Spinka.Application.Dispatchers.Queries
{
    public interface IQueryDispatcher
    {
        Task<TResult> QueryAsync<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>;
    }
}