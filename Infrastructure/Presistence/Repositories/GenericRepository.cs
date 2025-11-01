using Domain.Contracts;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Presistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presistence.Repositories
{
    internal class GenericRepository<TEntity, TKey>(StoreDbContext _dbContext) : IGenericRepository<TEntity, TKey> where TEntity : BaseEntity<TKey>
    {
        public async Task AddAsync(TEntity entity)
       =>await _dbContext.Set<TEntity>().AddAsync(entity);

        public void Delete(TEntity entity)
       => _dbContext.Set<TEntity>().Remove(entity);

        public async Task<IEnumerable<TEntity>> GetAllAsync(bool asNoTracking = false)=>
            asNoTracking? await _dbContext.Set<TEntity>().AsNoTracking().ToListAsync() :
               await _dbContext.Set<TEntity>().ToListAsync();

        public void Update(TEntity entity)
         => _dbContext.Set<TEntity>().Update(entity);

        public async Task<TEntity?> GetByIdAsync(TKey id)
        =>await _dbContext.Set<TEntity>().FindAsync(id);

        public async Task<TEntity?> GetByIdAsync(ISpecifications<TEntity, TKey> specifications)
        {
        return  await SpecificationsEvluator.CreateQuery(_dbContext.Set<TEntity>(), specifications).FirstOrDefaultAsync();
           
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(ISpecifications<TEntity, TKey> specifications)
        {
         return await SpecificationsEvluator.CreateQuery(_dbContext.Set<TEntity>(), specifications).ToListAsync();
        }

       
    }
}
