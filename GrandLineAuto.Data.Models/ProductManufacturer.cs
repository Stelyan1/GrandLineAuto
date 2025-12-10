using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandLineAuto.Data.Models
{
    public class ProductManufacturer
    {
        [Comment("Identifier of manufacturer")]
        public Guid Id { get; set; }

        [Comment("Name of the manufacturer")]
        public string Name { get; set; } = null!;

        [Comment("Product manufacturer has many products")]
        public ICollection<Product> Products { get; set; } = new HashSet<Product>();
    }
}
