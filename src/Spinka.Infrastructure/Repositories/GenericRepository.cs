using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Spinka.Domain.Repositories;
using Spinka.Infrastructure.Database;

namespace Spinka.Infrastructure.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly SpinkaContext _context;

        public GenericRepository(SpinkaContext context)
        {
            _context = context;
        }

        public async Task AddAsync(TEntity entity)
        {
            //entity.CreatedOnUtc = DateTime.UtcNow;
            await _context.Set<TEntity>().AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _context.Set<TEntity>().AddRangeAsync(entities);
        }

        public void Edit(TEntity entity)
        {
            //entity.ModifiedOnUtc = DateTime.UtcNow;
            // _context.Set<TEntity>().Attach(entity);
            // _context.Entry(entity).State = EntityState.Modified;
            _context.Set<TEntity>().Update(entity);
        }

        public async Task EditAsync(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
            await Task.CompletedTask;
        }

        public void EditRange(IEnumerable<TEntity> entities)
        {
            //entity.ModifiedOnUtc = DateTime.UtcNow;
            // var entities = entity.ToList();
            // _context.Set<TEntity>().AttachRange(entities);
            // _context.Entry(entities).State = EntityState.Modified;
            _context.Set<TEntity>().UpdateRange(entities);
        }

        public async Task EditRangeAsync(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().UpdateRange(entities);
            await Task.CompletedTask;
        }

        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public async Task DeleteAsync(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            await Task.CompletedTask;
        }

        public void DeleteRange(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().RemoveRange(entities);
        }
        
        public async Task DeleteRangeAsync(IEnumerable<TEntity> entities)
        {
            _context.Set<TEntity>().RemoveRange(entities);
            await Task.CompletedTask;
        }

        public async Task<TEntity> FindByIdAsync(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task<TEntity> FindByAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>()
                .AsNoTracking()
                .SingleOrDefaultAsync(predicate);
        }
        
        public async Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>()
                .Where(predicate)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>()
                .AsNoTracking()
                .ToListAsync();
        }
        
        public async Task<TEntity> FindByWithIncludesAsync(Expression<Func<TEntity, bool>> predicate, 
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes)
        {
            IQueryable<TEntity> queryable = _context.Set<TEntity>();

            if (includes != null)
            {
                queryable = includes(queryable);
            }

            return await queryable
                .AsNoTracking()
                .SingleOrDefaultAsync(predicate);
        }

        public async Task<IEnumerable<TEntity>> FindAllWithIncludesAsync(Expression<Func<TEntity, bool>> predicate, 
            Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes)
        {
            IQueryable<TEntity> queryable = _context.Set<TEntity>();

            if (includes != null)
            {
                queryable = includes(queryable);
            }

            return await queryable
                .Where(predicate)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<IEnumerable<TEntity>> GetAllWithIncludesAsync(Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes)
        {
            IQueryable<TEntity> queryable = _context.Set<TEntity>();

            if (includes != null)
            {
                queryable = includes(queryable);
            }

            return await queryable
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<TEntity> ExecuteSqlToSingleResult(string sql)
            => await _context.Set<TEntity>()
                .FromSqlRaw(sql)
                .AsNoTracking()
                .SingleAsync();
        
        // public async Task ClearAsync()
        // {
        //     var entity = _context.Model.GetEntityTypes().FirstOrDefault(x => x.ClrType == typeof(TEntity));
        //     if (entity == null)
        //     {
        //         throw new Exception($"Table for {typeof(TEntity).Name} does not exists in the model");
        //     }
        //
        //     await _context.Database.ExecuteSqlCommandAsync($"DELETE FROM [{entity.GetTableName()}]", entity.GetTableName());
        // }
    }
}
