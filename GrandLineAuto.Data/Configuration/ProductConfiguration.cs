using GrandLineAuto.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandLineAuto.Data.Configuration
{
    using static GrandLineAuto.Common.EntityValidation.Product;
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);

            builder.HasOne(p => p.ProductManufacturer)
                   .WithMany(pm => pm.Products)
                   .HasForeignKey(p => p.ProductManufacturerId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.SubCategory)
                   .WithMany(sc => sc.Products)
                   .HasForeignKey(p => p.SubCategoryId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Property(p => p.Name)
                   .IsRequired()
                   .HasMaxLength(ProductNameMaxLength);

            builder.Property(p => p.ImageUrl)
                   .IsRequired(); 

            builder.Property(p => p.Description)
                   .IsRequired()
                   .HasMaxLength(DescriptionMaxLength);

            builder.Property(p => p.SpecificInfo1);
            builder.Property(p => p.SpecificInfo2);
            builder.Property(p => p.SpecificInfo3);
            builder.Property(p => p.SpecificInfo4);
            builder.Property(p => p.SpecificInfo5);
            builder.Property(p => p.SpecificInfo6);

            builder.Property(p => p.Price)
                   .IsRequired()
                   .HasPrecision(18, 2);

            builder.HasData(SeedProducts());
        }

        private IEnumerable<Product> SeedProducts()
        {
            IEnumerable<Product> products = new List<Product>()
            {
                new Product()
                {
                    Id = Guid.Parse("f4a9d0c2-8b11-4e35-b6f2-9c7a1d54e820"),
                    Name = "Brembo XTRA LINE P 06 036X",
                    ImageUrl = "https://www.autopower.bg/images/%D0%BD%D0%B0%D0%BA%D0%BB%D0%B0%D0%B4%D0%BA%D0%B8-BREMBO-XTRA-LINE-P06036X-BMW-3-Cabrio-E93-330-i-imagetabig-845520901733463-BREMBO.jpg",
                    Description = "Brembo Xtra: the perfect brake pad for Brembo Xtra and Brembo Max brake discs.",
                    SpecificInfo1 = "Installation side: Front axle",
                    SpecificInfo2 = "width [mm]: 155mm",
                    SpecificInfo3 = "thickness [mm]: 20mm",
                    SpecificInfo4 = "height [mm]: 64mm",
                    Price = new Decimal(225.45),
                    SubCategoryId = new Guid("a3f79de2-58c4-49e8-9b6b-e24fdc81f927"),
                    ProductManufacturerId = new Guid("2c9f4b17-63e1-4e8a-8f5c-91d2a7b6c014")
                },

                new Product()
                {
                    Id = Guid.Parse("7e24b1c9-3a5f-44d0-9e72-0c1fb78d4aa3"),
                    Name = "Brembo XTRA Line - Xtra",
                    ImageUrl = "https://www.autopower.bg/images/%D1%81%D0%BF%D0%B8%D1%80%D0%B0%D1%87%D0%B5%D0%BD-%D0%B4%D0%B8%D1%81%D0%BA-BREMBO-XTRA-LINE-Xtra-0997931X-BMW-3-Sedan-E90-320-i-imagetabig-845520901699346-BREMBO.jpg",
                    Description = "The specific drilling of Brembo Xtra brake discs provides a brilliant and efficient performance in any braking condition, to emphasise the driving style of true enthusiasts.",
                    SpecificInfo1 = "Brake disc thickness [mm]:   20mm",
                    SpecificInfo2 = "height [mm]: 66mm",
                    SpecificInfo3 = "centering diameter [mm]: 75mm",
                    SpecificInfo4 = "outer diameter [mm]: 300mm",
                    SpecificInfo5 = "processing:  high-carbon",
                    Price = new Decimal(240.50),
                    SubCategoryId = new Guid("0be4c29f-3f11-4a88-bd42-89e1cf72d4a3"),
                    ProductManufacturerId = new Guid("2c9f4b17-63e1-4e8a-8f5c-91d2a7b6c014")
                },
            };
            return products;
        }
    }
}
