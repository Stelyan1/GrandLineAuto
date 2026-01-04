using GrandLineAuto.Data.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GrandLineAuto.Areas.Admin.Views.Models
{
    public class SubCategoryVM
    {
        [Comment("Identifier of subCategory")]
        public Guid Id { get; set; }

        [Comment("Name of the subCategory")]
        public string Name { get; set; } = null!;

        [Comment("Image of the subCategory")]
        public string ImageUrl { get; set; } = null!;

        [Comment("Identifier of the category")]
        public Guid CategoryId { get; set; }
        public IEnumerable<SelectListItem> Categories { get; set; } = new HashSet<SelectListItem>();
    }
}
