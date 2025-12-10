using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandLineAuto.Data.Models
{
    public class Product
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
        public SubCategory subCategory { get; set; } = null!;

        [Comment("Each product have manufacturer")]
        public Guid ProductManufacturerId { get; set; }
        public ProductManufacturer ProductManufacturer { get; set; } = null!; 
    }
}
