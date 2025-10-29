using Domain.Contracts;
using Domain.Entities;
using Presistence.Data;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly StoreDbContext _dbcontext;
        private ConcurrentDictionary <string, object> _repositories;
        public UnitOfWork(StoreDbContext dbcontext)
        {
            _dbcontext = dbcontext;
            _repositories = new(); 
        }
        
        public IGenericRepository<TEntity, TKey> GetRepository<TEntity, TKey>() where TEntity : BaseEntity<TKey>
            =>
            (IGenericRepository<TEntity, TKey>)_repositories.GetOrAdd(typeof(TEntity).Name, 
                (_) => new GenericRepository<TEntity, TKey>(_dbcontext));

        //{
        //   var key=typeof(TEntity).Name;
        //    if (_repositories.ContainsKey(key))
        //        _repositories[key]= new GenericRepository<TEntity, TKey>(_dbcontext);
        //    return (IGenericRepository<TEntity, TKey>)_repositories[key];

        //}

        public async Task<int> SaveChangesAsync()
        =>
           await _dbcontext.SaveChangesAsync(); 
        
    }
}
