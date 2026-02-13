using GrandLineAuto.Data.Models.OrderEntities.Enums;
using GrandLineAuto.Infrastructure.Options;
using GrandLineAuto.Infrastructure.Services.Payments;
using GrandLineAuto.Infrastructure.Services.Purchasing.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Stripe;
using Stripe.Checkout;
using PaymentMethod = GrandLineAuto.Data.Models.OrderEntities.Enums.PaymentMethod;

namespace GrandLineAuto.Controllers
{
    [Route("payments")]
    public class PaymentsController : Controller
    {
        private readonly StripeSettings _stripe;
        private readonly IStripePaymentService _stripePayment;
        private readonly IOrderService _orderService;

        public PaymentsController(IOptions<StripeSettings> stripe, IStripePaymentService stripePayment, IOrderService orderService)
        {
            _stripe = stripe.Value;
            _stripePayment = stripePayment;
            _orderService = orderService;
        }

        [IgnoreAntiforgeryToken]
        [HttpPost("stripe/create-session")]
        public async Task<IActionResult> CreateStripeSession(Guid orderId)
        {
            //var order = await _orderService.GetByIdAsync(orderId);
            //if (order == null) return NotFound();

            //if (order.PaymentMethod != PaymentMethod.Card)
            //    return BadRequest("Order payment method is not Card.");

            //if (order.PaymentStatus != PaymentStatus.Pending)
            //    return BadRequest("Order doesn't have pending payment.");

            var order = await _orderService.GetByIdAsync(orderId);
            if (order == null) return BadRequest("Order not found.");

            if (order.PaymentMethod != PaymentMethod.Card)
                return BadRequest($"PaymentMethod is {order.PaymentMethod}, expected Card.");

            if (order.PaymentStatus != PaymentStatus.Pending)
                return BadRequest($"PaymentStatus is {order.PaymentStatus}, expected Pending.");

            if (order.TotalAmount <= 0)
                return BadRequest($"TotalAmount is {order.TotalAmount}, invalid.");

            var successUrl = Url.Action(
               "Success",
               "Orders",
               new { id = orderId },
               Request.Scheme
               )!;

            var cancelUrl = Url.Action(
                "Pay",
                "Orders",
                new { id = orderId },
                Request.Scheme
            )!;

            var (publishableKey, sessionId) = await _stripePayment.CreateCheckoutSessionAsync(
                order.Id,
                order.TotalAmount,
                successUrl,
                cancelUrl);

            await _orderService.SetStripeSessionIdAsync(orderId, sessionId);

            return Json(new { publishableKey, sessionId });
        }

        [IgnoreAntiforgeryToken]
        [HttpPost("stripe/webhook")]
        public async Task<IActionResult> StripeWebhook()
        {
            var json = await new StreamReader(Request.Body).ReadToEndAsync();
            var signature = Request.Headers["Stripe-Signature"].ToString();

            Event stripeEvent;
            try
            {
                stripeEvent = EventUtility.ConstructEvent(json, signature, _stripe.WebhookSecret);
            }
            catch
            {
                return BadRequest();
            }

            if(stripeEvent.Type == "checkout.session.completed")
            {
                var session = stripeEvent.Data.Object as Session;

                if(session?.Id != null)
                {
                    var order = await _orderService.GetByStripeSessionIdAsync(session.Id);
                    if(order != null && order.PaymentStatus != PaymentStatus.Paid)
                    {
                        await _orderService.MarkPaidAsync(order.Id, session.PaymentIntentId ?? "");
                    }
                }
            }

            return Ok();
        }
    }
}
