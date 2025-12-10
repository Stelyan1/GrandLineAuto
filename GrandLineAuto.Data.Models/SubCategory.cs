using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandLineAuto.Data.Models
{
    public class SubCategory
    {
        [Comment("Identifier of subCategory")]
        public Guid Id { get; set; }

        [Comment("Name of the subCategory")]
        public string Name { get; set; } = null!;

        [Comment("Image of the subCategory")]
        public string ImageUrl { get; set; } = null!;

        [Comment("Identifier of the category")]
        public Guid CategoryId { get; set; }
        public Category Category { get; set; } = null!;

        [Comment("Each subCategory has a products")]
        public ICollection<Product> Products { get; set; } = new HashSet<Product>();
    }
}
