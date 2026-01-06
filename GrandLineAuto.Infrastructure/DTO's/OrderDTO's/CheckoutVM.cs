using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandLineAuto.Infrastructure.DTO_s.OrderDTO_s
{
    public class CheckoutVM
    {
        [Required]
        [MaxLength(100)]
        public string FullName { get; set; } = null!;

        [Required]
        [MaxLength(20)]
        public string Phone { get; set; } = null!;

        [Required]
        [MaxLength(200)]
        public string AddressLine1 { get; set; } = null!;

        [MaxLength(200)]
        public string? AddressLine2 { get; set; }

        [Required]
        [MaxLength(80)]
        public string City { get; set; } = null!;

        [MaxLength(20)]
        public string? PostalCode { get; set; }

        
        [Required]
        public string PaymentMethod { get; set; } = "Card";
    }
}
