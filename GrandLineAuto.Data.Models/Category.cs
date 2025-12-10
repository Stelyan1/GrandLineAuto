using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandLineAuto.Data.Models
{
    public class Category
    {
        [Comment("Identifier of category")]
        public Guid Id {  get; set; }

        [Comment("Name of category")]
        public string Name { get; set; } = null!;

        [Comment("Image of the category")]
        public string ImageUrl { get; set; } = null!;

        [Comment("It has sub cateogries")]
        public ICollection<SubCategory> subCategories { get; set; } = new HashSet<SubCategory>();
    }
}
