using GrandLineAuto.Data.Models.CartEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandLineAuto.Infrastructure.Repositories.Purchasing.Interfaces
{
    public interface ICartRepository
    {
        IQueryable<CartItem> All();
        Task AddAsync(CartItem item);
        void Update(CartItem item);
        void Remove(CartItem item);
    }
}
