using System.Collections.Generic;
using System.Threading.Tasks;

namespace Spinka.Domain.Repositories
{
    public interface IRepositoryHelper<T> where T : class
    {
        Task<IEnumerable<T>> ExecuteSqlProcedureToSingleResult(string procedureName,
            List<object> paramsToCondition, params string[] parameters);

        Task<IEnumerable<T>> ExecuteSqlProcedure(string procedureName, params string[] parameters);
    }
}