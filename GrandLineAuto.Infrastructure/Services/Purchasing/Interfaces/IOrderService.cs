using GrandLineAuto.Data.Models.OrderEntities;
using GrandLineAuto.Infrastructure.DTO_s.OrderDTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandLineAuto.Infrastructure.Services.Purchasing.Interfaces
{
    public interface IOrderService
    {
        Task<Guid> CheckoutAsync(Guid userId, CheckoutVM model);


        //Stripe services
        Task SetStripeSessionIdAsync(Guid orderId, string sessionId);
        Task<Order?> GetByStripeSessionIdAsync(string sessionId);
        Task MarkPaidAsync(Guid orderId, string paymentIntentId);

        Task<Order?> GetByIdAsync(Guid orderId);
    }
}
