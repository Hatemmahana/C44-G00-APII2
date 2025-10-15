using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presistence.Repositories
{
    public class UnitOfWork : IUnitOfWorkk

    {
        private readonly StoreDbContext dbContext;
        private ConcurrentDictionary<string, object> _repositories;

        public UnitOfWork(StoreDbContext _dbContext) 
        {
            dbContext = _dbContext;
            _repositories = new ConcurrentDictionary<string, object>();
        }

        public IGenericRepository<TEntity, TKey> GetRepository<TEntity, TKey>()
    where TEntity : BaseEntity<TKey>
    => (IGenericRepository<TEntity, TKey>)_repositories
        .GetOrAdd(typeof(TEntity).Name, _ => new GenericRepository<TEntity, TKey>(dbContext));

        public async Task<int> SaveChanges()
       
            =>await dbContext.SaveChangesAsync();
        
    }
}
