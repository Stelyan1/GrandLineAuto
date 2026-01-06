using GrandLineAuto.Data.Models.OrderEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandLineAuto.Infrastructure.Repositories.Purchasing.Interfaces
{
    public interface IOrderRepository
    {
        Task AddAsync(Order order);
    }
}
