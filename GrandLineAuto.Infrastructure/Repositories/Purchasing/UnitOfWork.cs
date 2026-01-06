using GrandLineAuto.Data;
using GrandLineAuto.Infrastructure.Repositories.Purchasing.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandLineAuto.Infrastructure.Repositories.Purchasing
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GrandLineAutoDbContext _dbContext;

        public UnitOfWork(GrandLineAutoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task<int> SaveChangesAsync()
        {
           return _dbContext.SaveChangesAsync();
        }
    }
}
