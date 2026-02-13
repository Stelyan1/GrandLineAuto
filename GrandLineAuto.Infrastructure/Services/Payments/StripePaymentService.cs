using GrandLineAuto.Infrastructure.Options;
using Microsoft.Extensions.Options;

using Stripe.Checkout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandLineAuto.Infrastructure.Services.Payments
{
    public class StripePaymentService : IStripePaymentService
    {
        private readonly StripeSettings _settings;

        public StripePaymentService(IOptions<StripeSettings> settings)
        {
            _settings = settings.Value;
        }

        public async Task<(string publishableKey, string sessionId)> CreateCheckoutSessionAsync(
            Guid orderId, 
            decimal totalAmountEur, 
            string successUrl, 
            string cancelUrl)
        {
            var amountCents = (long)Math.Truncate(totalAmountEur * 100m);

            var options = new SessionCreateOptions
            {
                Mode = "payment",
                SuccessUrl = successUrl,
                CancelUrl = cancelUrl,

                //ClientReferenceId = orderId.ToString(),
                Metadata = new Dictionary<string, string>
                {
                    ["orderId"] = orderId.ToString()
                },

                LineItems = new List<SessionLineItemOptions>
                {
                    new SessionLineItemOptions
                    {
                        Quantity = 1,
                        PriceData = new SessionLineItemPriceDataOptions
                        {
                            Currency = "eur",
                            UnitAmount = amountCents,
                            ProductData = new SessionLineItemPriceDataProductDataOptions
                            {
                                Name = $"GrandLineAuto Order {orderId}"
                            }
                        }
                    }
                }
            };

            var sessionService = new SessionService();
            var session = await sessionService.CreateAsync(options);

            return (_settings.PublishableKey, session.Id);
        }
    }
}
