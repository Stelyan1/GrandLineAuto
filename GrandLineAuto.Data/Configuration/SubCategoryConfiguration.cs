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
    using static GrandLineAuto.Common.EntityValidation.SubCategory;
    public class SubCategoryConfiguration : IEntityTypeConfiguration<SubCategory>
    {
        public void Configure(EntityTypeBuilder<SubCategory> builder)
        {
            builder.HasKey(sc => sc.Id);

            builder.HasOne(sc => sc.Category)
                   .WithMany(c => c.subCategories)
                   .HasForeignKey(sc => sc.CategoryId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Property(sc => sc.Name)
                   .IsRequired()
                   .HasMaxLength(SubCategoryNameMaxLength);

            builder.Property(sc => sc.ImageUrl)
                   .IsRequired();

            builder.HasData(SeedSubCategory());
        }

        private IEnumerable<SubCategory> SeedSubCategory()
        {
            IEnumerable<SubCategory> subCategories = new List<SubCategory>()
            {
                new SubCategory()
                {
                    Id = Guid.Parse("0be4c29f-3f11-4a88-bd42-89e1cf72d4a3"),
                    Name = "Brake discs",
                    ImageUrl = "https://www.autopower.bg/images/categories/75x75/%D0%A1%D0%BF%D0%B8%D1%80%D0%B0%D1%87%D0%BD%D0%B8%20%D0%B4%D0%B8%D1%81%D0%BA%D0%BE%D0%B2%D0%B5.jpg",
                    CategoryId = new Guid("5a3d9c41-7f2b-4e8c-9c31-0fb28d74a922")
                },

                new SubCategory()
                {
                    Id = Guid.Parse("a3f79de2-58c4-49e8-9b6b-e24fdc81f927"),
                    Name = "Overlays",
                    ImageUrl = "https://www.autopower.bg/images/categories/75x75/%D0%9D%D0%B0%D0%BA%D0%BB%D0%B0%D0%B4%D0%BA%D0%B8.jpg",
                    CategoryId = new Guid("5a3d9c41-7f2b-4e8c-9c31-0fb28d74a922")
                },

                new SubCategory()
                {
                    Id = Guid.Parse("6cd1f0b8-92b5-45a4-a6c1-3f84d9c2b7e0"),
                    Name = "Timing Chain",
                    ImageUrl = "https://www.autopower.bg/images/categories/75x75/%D0%90%D0%BD%D0%B3%D1%80%D0%B5%D0%BD%D0%B0%D0%B6%D0%BD%D0%B0%20%D0%B2%D0%B5%D1%80%D0%B8%D0%B3%D0%B0.png",
                    CategoryId = new Guid("d4f0a8c7-12b9-4c53-8d77-61f4b3e2c915")
                },

                new SubCategory()
                {
                    Id = Guid.Parse("f29b31c4-0e52-4c7d-8b1f-9e4da37c1aa6"),
                    Name = "EGR valve",
                    ImageUrl = "https://www.autopower.bg/images/categories/75x75/EGR%20%D0%BA%D0%BB%D0%B0%D0%BF%D0%B0%D0%BD.png",
                    CategoryId = new Guid("d4f0a8c7-12b9-4c53-8d77-61f4b3e2c915")
                }
            };
            return subCategories;
        }
    }
}
