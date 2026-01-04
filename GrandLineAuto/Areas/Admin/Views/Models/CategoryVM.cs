using Microsoft.EntityFrameworkCore;

namespace GrandLineAuto.Areas.Admin.Views.Models
{
    public class CategoryVM
    {
        [Comment("Identifier of category")]
        public Guid Id { get; set; }

        [Comment("Name of category")]
        public string Name { get; set; } = null!;

        [Comment("Image of the category")]
        public string ImageUrl { get; set; } = null!;
    }
}
