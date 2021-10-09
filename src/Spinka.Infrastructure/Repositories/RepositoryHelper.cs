using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Spinka.Domain.Repositories;
using Spinka.Infrastructure.Database;

namespace Spinka.Infrastructure.Repositories
{
    public class RepositoryHelper<T> : IRepositoryHelper<T> where T : class
    {
        private readonly SpinkaContext _context;

        public RepositoryHelper(SpinkaContext context)
        {
            _context = context;
        }
        
        public async Task<IEnumerable<T>> ExecuteSqlProcedureToSingleResult(string procedureName,
            List<object> paramsToCondition, params string[] parameters)
        {
            var procedureParams = new List<object>();
            
            for (var i = 0; i < parameters.Length; i++)
            {
                for (var j = 0; j < paramsToCondition.Count; j++)
                {
                    if (i != j) 
                        continue;
                    
                    procedureParams.Add(new SqlParameter(parameters[i], paramsToCondition[j]));
                    break;
                }
            }
            
            var sqlQuery = new StringBuilder();
            sqlQuery.AppendFormat(@"EXECUTE {0} ", procedureName);

            foreach (var param in parameters)
            {
                sqlQuery.Append($"{param}, ");
            }

            sqlQuery.Remove(sqlQuery.Length - 2, 2);

            var result = await _context.Set<T>()
                .FromSqlRaw(sqlQuery.ToString(), procedureParams.ToArray())
                .ToListAsync();

            return result;
        }

        public Task<IEnumerable<T>> ExecuteSqlProcedure(string procedureName, params string[] parameters)
        {
            throw new System.NotImplementedException();
        }
    }
}