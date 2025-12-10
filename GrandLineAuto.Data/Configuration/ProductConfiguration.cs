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
                   .IsRequired();

        }
    }
}
