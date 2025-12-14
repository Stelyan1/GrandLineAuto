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
    public class BrandModelsProductJoinTableConfiguration : IEntityTypeConfiguration<BrandModelProductJoinTable>
    {
        public void Configure(EntityTypeBuilder<BrandModelProductJoinTable> builder)
        {
            builder.HasKey(bmp => new { bmp.BrandModelId, bmp.ProductId });

            builder.HasOne(bmp => bmp.BrandModels)
                   .WithMany(bm => bm.BrandModelsProducts)
                   .HasForeignKey(bmp => bmp.BrandModelId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(bmp => bmp.Products)
                   .WithMany(p => p.BrandModelsProducts)
                   .HasForeignKey(bmp => bmp.ProductId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(SeedBrandModelProductJoinTable());
        }

        private IEnumerable<BrandModelProductJoinTable> SeedBrandModelProductJoinTable()
        {
            IEnumerable<BrandModelProductJoinTable> brandModelProducts = new List<BrandModelProductJoinTable>()
            {
                new BrandModelProductJoinTable()
                {
                    BrandModelId = new Guid("4e8c1f22-9d4b-4f36-a7c1-2b9f53d1e8aa"),
                    ProductId = new Guid("f4a9d0c2-8b11-4e35-b6f2-9c7a1d54e820")
                },

                new BrandModelProductJoinTable()
                {
                    BrandModelId = new Guid("9cbf2146-7c33-4a51-9f2c-41e7a4d92bb8"),
                    ProductId = new Guid("f4a9d0c2-8b11-4e35-b6f2-9c7a1d54e820")
                },

                new BrandModelProductJoinTable()
                {
                    BrandModelId = new Guid("31c4e0aa-9f12-4b0d-8f7e-55a1cb2d7c44"),
                    ProductId = new Guid("7e24b1c9-3a5f-44d0-9e72-0c1fb78d4aa3")
                },

                new BrandModelProductJoinTable()
                {
                    BrandModelId = new Guid("7de41fa8-1c26-4f3e-9d72-04c9fd8a33b7"),
                    ProductId = new Guid("7e24b1c9-3a5f-44d0-9e72-0c1fb78d4aa3")
                }
            };
            return brandModelProducts;
        }
    }
}
