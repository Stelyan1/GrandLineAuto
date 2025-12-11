using GrandLineAuto.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GrandLineAuto.Data.Configuration
{
    using static GrandLineAuto.Common.EntityValidation.Brand;
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Name)
                   .IsRequired()
                   .HasMaxLength(BrandNameMaxLength);

            builder.Property(b => b.ImageUrl)
                   .IsRequired();

            builder.HasData(SeedBrands());
        }

        private IEnumerable<Brand> SeedBrands()
        {
            IEnumerable<Brand> brands = new List<Brand>()
            {
                new Brand()
                {
                  Id = Guid.Parse("3f6c9c77-4c1b-4d2b-9df2-1e8e4c27bba4"),
                  Name = "BMW",
                  ImageUrl = "https://blog.logomaster.ai/hs-fs/hubfs/bmw-logo-1963.jpg?width=672&height=454&name=bmw-logo-1963.jpg"
                },

                new Brand()
                {
                    Id = Guid.Parse("9b2f1c3d-2f50-4c4c-b4ce-0f7d7f2c9f61"),
                    Name = "Mercedes-Benz",
                    ImageUrl = "https://static.vecteezy.com/system/resources/previews/020/499/027/non_2x/mercedes-benz-brand-logo-symbol-white-with-name-design-german-car-automobile-illustration-with-black-background-free-vector.jpg"
                },

                new Brand()
                {
                    Id = Guid.Parse("c4c8a1c9-7c29-4d47-8c19-3e9d2ef0be55"),
                    Name = "Audi",
                    ImageUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/a/ae/Logo_audi.jpg/960px-Logo_audi.jpg"
                },

                new Brand()
                {
                    Id = Guid.Parse("0a7cb569-2e0e-4c76-a28e-92e3d355fa28"),
                    Name = "Porsche",
                    ImageUrl = "https://images.seeklogo.com/logo-png/16/1/porsche-logo-png_seeklogo-168544.png"
                }
            };
            return brands;
        }
    }
}
