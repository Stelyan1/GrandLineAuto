using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandLineAuto.Infrastructure.Services.Purchasing.Interfaces
{
    public interface ICartService
    {
        Task AddAsync(Guid userId, Guid productId, int quantity);
    }
}
