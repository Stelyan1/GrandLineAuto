using GrandLineAuto.Data.Models.UserEntities;
using GrandLineAuto.Data.Models.OrderEntities.Enums;
using Stripe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaymentMethod = GrandLineAuto.Data.Models.OrderEntities.Enums.PaymentMethod;

namespace GrandLineAuto.Data.Models.OrderEntities
{
    public class Order
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid UserId { get; set; }
        public ApplicationUser User { get; set; } = null!;

        public DateTime CreatedOnUtc { get; set; } = DateTime.UtcNow;
        public OrderStatus Status { get; set; } = OrderStatus.Pending;

        public decimal TotalAmount { get; set; }

        public ShippingAddress ShippingAddress { get; set; } = null!;

        public ICollection<OrderItem> Items { get; set; } = new List<OrderItem>();

        //Adding Real Card Payment
        public PaymentMethod PaymentMethod { get; set; } = PaymentMethod.CashOnDelivery;
        public PaymentStatus PaymentStatus { get; set; } = PaymentStatus.Pending;

        public string? StripeSessionId { get; set; }
        public string? StripePaymentIntentId { get; set; }
    }
}
