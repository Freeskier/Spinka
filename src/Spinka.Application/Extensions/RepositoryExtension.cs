using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Query;
using Spinka.Application.Exceptions;
using Spinka.Domain.Repositories;

namespace Spinka.Application.Extensions
{
    public static class RepositoryExtension
    {
        public static async Task<TEntity> GetOrFailAsync<TEntity>(this IGenericRepository<TEntity> repository, int id) where TEntity : class 
        {
            var entity = await repository.FindByIdAsync(id);

            if (entity == null)
            {
                throw new BusinessException(ErrorCodes.NoExist, $"{typeof(TEntity).Name} with id: {id} does not exist");
            }

            return entity;
        }
        
        public static async Task<TEntity> GetOrFailAsync<TEntity>(this IGenericRepository<TEntity> repository, 
            Expression<Func<TEntity, bool>> predicate) where TEntity : class 
        {
            var entity = await repository.FindByAsync(predicate);

            if (entity == null)
            {
                throw new BusinessException(ErrorCodes.NoExist, $"{typeof(TEntity).Name} does not exist");
            }

            return entity;
        }
        
        public static async Task<TEntity> GetOrFailWithCheckExistsAsync<TEntity>(this IGenericRepository<TEntity> repository, 
            Expression<Func<TEntity, bool>> predicate) where TEntity : class 
        {
            var entity = await repository.FindByAsync(predicate);

            if (entity != null)
            {
                throw new BusinessException(ErrorCodes.Exist, $"{typeof(TEntity).Name} exists");
            }

            return null;
        }
        
        public static async Task<TEntity> GetOrFailWithIncludesAsync<TEntity>(this IGenericRepository<TEntity> repository, 
            Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes) where TEntity : class 
        {
            var entity = await repository.FindByWithIncludesAsync(predicate, includes);

            if (entity == null)
            {
                throw new BusinessException(ErrorCodes.NoExist, $"{typeof(TEntity).Name} does not exist");
            }

            return entity;
        }
    }
}