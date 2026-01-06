using GrandLineAuto.Data;
using GrandLineAuto.Data.Models.OrderEntities;
using GrandLineAuto.Infrastructure.Repositories.Purchasing.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandLineAuto.Infrastructure.Repositories.Purchasing
{
    public class OrderRepository : IOrderRepository
    {
        private readonly GrandLineAutoDbContext _dbContext;

        public OrderRepository(GrandLineAutoDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task AddAsync(Order order)
        {
           await _dbContext.Orders.AddAsync(order);
        }
    }
}
