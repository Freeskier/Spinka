using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Spinka.Domain.Repositories;
using Spinka.Infrastructure.Database;

namespace Spinka.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SpinkaContext _context;
        private readonly Dictionary<Type, object> _repositories = new Dictionary<Type, object>();
        
        public UnitOfWork(SpinkaContext context)
        {
            _context = context;
        }
        
        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            if (_repositories.Keys.Contains(typeof(TEntity)))
            {
                return _repositories[typeof(TEntity)] as IGenericRepository<TEntity>;
            }

            IGenericRepository<TEntity> repository = new GenericRepository<TEntity>(_context);
            _repositories.Add(typeof(TEntity), repository);
            return repository;
        }

        public async Task<int> Commit()
        {
            return await _context.SaveChangesAsync();
        }
        

        public void Rollback()
        {
            _context.ChangeTracker.Entries().ToList().ForEach(x => x.Reload());
        }
    }
}