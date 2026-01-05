using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandLineAuto.Data.Models.OrderEntities
{
    public class ShippingAddress
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid OrderId { get; set; }
        public Order Order { get; set; } = null!;

        public string FullName { get; set; } = null!;
        public string Phone { get; set; } = null!;

        public string AddressLine1 { get; set; } = null!;
        public string? AddressLine2 { get; set; }

        public string City { get; set; } = null!;
        public string? PostalCode { get; set; }
        public string Country { get; set; } = "Bulgaria";
    }
}
