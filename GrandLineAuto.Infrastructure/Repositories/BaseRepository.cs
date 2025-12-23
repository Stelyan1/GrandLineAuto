using GrandLineAuto.Data;
using GrandLineAuto.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandLineAuto.Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly GrandLineAutoDbContext _dbContext;
        private readonly DbSet<T> _dbSet;

        public BaseRepository(GrandLineAutoDbContext dbContext)
        {
            this._dbContext = dbContext;
            this._dbSet = _dbContext.Set<T>();
        }

        public async Task AddAsync(T Entity)
        {
            await _dbSet.AddAsync(Entity);
            await _dbContext.SaveChangesAsync();
        }

        public IQueryable<T> All()
        {
            return _dbSet.AsQueryable();
        }

        public IQueryable<T> AllForGivenEntity<Т>()
        {
            return _dbSet.AsQueryable<T>();
        }

        public void DeleteAsync(T Entity)
        {
            _dbSet.Remove(Entity);

        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(Guid guidId)
        {
            return await _dbSet.FindAsync(guidId);
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public void UpdateAsync(T Entity)
        {
            _dbSet.Update(Entity);
        }
    }
}
