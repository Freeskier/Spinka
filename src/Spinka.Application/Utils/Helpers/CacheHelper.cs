using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.Extensions.Caching.Memory;
using Spinka.Domain.Repositories;

namespace Spinka.Application.Utils.Helpers
{
    public static class CacheHelper
    {
        public static async Task SetCache<TEntity>(IUnitOfWork unitOfWork, IMemoryCache cache, string cacheAlias, 
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes) where TEntity : class 
        {
            var data = await unitOfWork.Repository<TEntity>()
                .GetAllWithIncludesAsync(includes);
            
            cache.Set(cacheAlias, data, TimeSpan.FromHours(1));
        }

        public static async Task<IEnumerable<TViewModel>> GetValueFromCache<TEntity, TViewModel>(IUnitOfWork unitOfWork, 
            IMemoryCache cache, IMapper mapper, string cacheAlias, 
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes) 
            where TEntity : class where TViewModel : class
        {
            if (cache.TryGetValue(cacheAlias, out IEnumerable<TEntity> data))
            {
                return mapper.Map<IEnumerable<TViewModel>>(data);
            }

            data = await unitOfWork.Repository<TEntity>()
                .GetAllWithIncludesAsync(includes);
            
            cache.Set(cacheAlias, data.ToList(), TimeSpan.FromHours(1));
            return mapper.Map<IEnumerable<TViewModel>>(data);
        }
        
        public static async Task<IEnumerable<TViewModel>> GetValueFromCacheWithCondition<TEntity, TViewModel>(IUnitOfWork unitOfWork, 
            IMemoryCache cache, IMapper mapper, string cacheAlias, Expression<Func<TEntity, bool>> predicate) 
            where TEntity : class where TViewModel : class
        {
            if (cache.TryGetValue(cacheAlias, out IEnumerable<TEntity> data))
            {
                return mapper.Map<IEnumerable<TViewModel>>(data.Where(predicate.Compile()));
            }
            
            data = await unitOfWork.Repository<TEntity>()
                .FindAllAsync(predicate);

            return mapper.Map<IEnumerable<TViewModel>>(data);
        }
    }
}