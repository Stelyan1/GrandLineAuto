using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandLineAuto.Infrastructure.Services.Payments
{
    public interface IStripePaymentService
    {
        Task<(string publishableKey, string sessionId)> CreateCheckoutSessionAsync(
            Guid orderId,
            decimal totalAmountEur,
            string successUrl,
            string cancelUrl);
    }
}
