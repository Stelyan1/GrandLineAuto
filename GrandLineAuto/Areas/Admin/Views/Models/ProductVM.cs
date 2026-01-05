using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GrandLineAuto.Areas.Admin.Views.Models
{
    public class ProductVM
    {
        [Comment("Identifier of product")]
        public Guid Id { get; set; }

        [Comment("Name of product")]
        public string Name { get; set; } = null!;

        [Comment("Image of the product")]
        public string ImageUrl { get; set; } = null!;

        [Comment("Information about the product")]
        public string Description { get; set; } = null!;

        [Comment("Information about the product")]
        public string SpecificInfo1 { get; set; } = string.Empty;
        [Comment("Information about the product")]
        public string SpecificInfo2 { get; set; } = string.Empty;
        [Comment("Information about the product")]
        public string SpecificInfo3 { get; set; } = string.Empty;
        [Comment("Information about the product")]
        public string SpecificInfo4 { get; set; } = string.Empty;
        [Comment("Information about the product")]
        public string SpecificInfo5 { get; set; } = string.Empty;
        [Comment("Information about the product")]
        public string SpecificInfo6 { get; set; } = string.Empty;

        [Comment("Price of the product")]
        public decimal Price { get; set; }

        [Comment("It has sub categories")]
        public Guid SubCategoryId { get; set; }
        public IEnumerable<SelectListItem> SubCategories { get; set; } = new HashSet<SelectListItem>();

        [Comment("Each product have manufacturer")]
        public Guid ProductManufacturerId { get; set; }
        public IEnumerable<SelectListItem> ProductManufacturers { get; set; } = new HashSet<SelectListItem>();

        public List<Guid> SelectedBrandModelIds { get; set; } = new();

        public IEnumerable<SelectListItem> BrandModels { get; set; } = Enumerable.Empty<SelectListItem>();
    }
}
