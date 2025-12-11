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
    using static GrandLineAuto.Common.EntityValidation.ProductManufacturer;
    public class ProductManufacturerConfiguration : IEntityTypeConfiguration<ProductManufacturer>
    {
        public void Configure(EntityTypeBuilder<ProductManufacturer> builder)
        {
            builder.HasKey(pm => pm.Id);

            builder.Property(pm => pm.Name)
                   .IsRequired()
                   .HasMaxLength(ProductManufacturerNameMaxLength);

            builder.HasData(SeedProductManufacturers());
        }

        private IEnumerable<ProductManufacturer> SeedProductManufacturers()
        {
            IEnumerable<ProductManufacturer> productManufacturers = new List<ProductManufacturer>()
            {
                new ProductManufacturer()
                {
                    Id = Guid.Parse("2c9f4b17-63e1-4e8a-8f5c-91d2a7b6c014"),
                    Name = "Brembo"
                },

                new ProductManufacturer()
                {
                    Id = Guid.Parse("b18e57d4-0fa2-41e3-9c42-7d3f1a8ce5b9"),
                    Name = "Metzger autotelie"
                },

                new ProductManufacturer()
                {
                    Id = Guid.Parse("94a0c6e3-2b71-4d8f-9f3e-0c8d27ab14d2"),
                    Name = "Febi bilstein"
                }
            };
            return productManufacturers;
        }
    }
}
