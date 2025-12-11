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
    using static GrandLineAuto.Common.EntityValidation.Category;
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Name)
                   .IsRequired()
                   .HasMaxLength(CategoryNameMaxLength);

            builder.Property(c => c.ImageUrl)
                   .IsRequired();

            builder.HasData(SeedCategories());
        }

        private IEnumerable<Category> SeedCategories()
        {
            IEnumerable<Category> categories = new List<Category>()
            {
                new Category()
                {
                    Id = Guid.Parse("5a3d9c41-7f2b-4e8c-9c31-0fb28d74a922"),
                    Name = "Braking System",
                    ImageUrl = "https://www.autopower.bg/images/categories/%D0%A1%D0%BF%D0%B8%D1%80%D0%B0%D1%87%D0%BD%D0%B0%20%D1%81%D0%B8%D1%81%D1%82%D0%B5%D0%BC%D0%B0.jpg"
                },

                new Category()
                {
                    Id = Guid.Parse("d4f0a8c7-12b9-4c53-8d77-61f4b3e2c915"),
                    Name = "Engine Parts",
                    ImageUrl = "https://www.autopower.bg/images/categories/%D0%A7%D0%B0%D1%81%D1%82%D0%B8%20%D0%B7%D0%B0%20%D0%B4%D0%B2%D0%B8%D0%B3%D0%B0%D1%82%D0%B5%D0%BB.jpg"
                }
            };
            return categories;
        }
    }
}
