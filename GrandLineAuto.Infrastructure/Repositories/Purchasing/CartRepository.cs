using GrandLineAuto.Data;
using GrandLineAuto.Data.Models.CartEntities;
using GrandLineAuto.Infrastructure.Repositories.Purchasing.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandLineAuto.Infrastructure.Repositories.Purchasing
{
    public class CartRepository : ICartRepository
    {
        private readonly GrandLineAutoDbContext _dbContext;

        public CartRepository(GrandLineAutoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(CartItem item)
        {
            await _dbContext.AddAsync(item);
        }

        public IQueryable<CartItem> All()
        {
            return _dbContext.CartItems.AsQueryable();
        }

        public void Remove(CartItem item)
        {
            _dbContext.CartItems.Remove(item);
        }

        public void Update(CartItem item)
        {
            _dbContext.CartItems.Update(item);
        }
    }
}
