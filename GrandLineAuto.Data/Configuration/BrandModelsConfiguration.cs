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
    using static GrandLineAuto.Common.EntityValidation.BrandModels;
    public class BrandModelsConfiguration : IEntityTypeConfiguration<BrandModels>
    {
        public void Configure(EntityTypeBuilder<BrandModels> builder)
        {
            builder.HasKey(bm => bm.Id);

            builder.HasOne(bm => bm.BrandModelsSeries)
                   .WithMany(bms => bms.BrandModels)
                   .HasForeignKey(bm => bm.BrandModelsSeriesId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Property(bm => bm.Name)
                   .IsRequired()
                   .HasMaxLength(BrandModelsNameMaxLength);

            builder.Property(bm => bm.ImageUrl)
                   .IsRequired();

            builder.Property(bm => bm.yearProduced)
                   .IsRequired();

            builder.Property(bm => bm.typeCoupe)
                   .IsRequired()
                   .HasMaxLength(typeCoupeMaxLength);

            builder.Property(bm => bm.fuelType)
                   .IsRequired()
                   .HasMaxLength(fuelUsageMaxLength);

            builder.Property(bm => bm.Engine)
                  .IsRequired()
                  .HasMaxLength(engineMaxLength);

            builder.HasData(SeedBrandModels());
        }

        private IEnumerable<BrandModels> SeedBrandModels()
        {
            IEnumerable<BrandModels> brandModels = new List<BrandModels>()
            {
                new BrandModels()
                {
                    Id = Guid.Parse("4e8c1f22-9d4b-4f36-a7c1-2b9f53d1e8aa"),
                    Name = "E90",
                    ImageUrl = "https://img-ik.cars.co.za/images/2022/12Dec/E90BMW3SeriesSedanBuyersGuide/tr:n-news_large/2007-m3-sedan-2.jpg?tr=w-800",
                    yearProduced = 2007,
                    typeCoupe = "Sedan",
                    fuelType = "Petrol",
                    Engine = "320i",
                    BrandModelsSeriesId = new Guid("e2f3b6c1-9c4d-4c88-86b8-7f92b1e4a6d2")
                },

                new BrandModels()
                {
                    Id = Guid.Parse("31c4e0aa-9f12-4b0d-8f7e-55a1cb2d7c44"),
                    Name = "E93",
                    ImageUrl = "https://www.automoli.com/common/vehicles/_assets/img/gallery/f98/bmw-3-series-convertible-e93-lci-facelift-2010.jpg",
                    yearProduced = 2009,
                    typeCoupe = "Cabrio",
                    fuelType = "Petrol",
                    Engine = "335i",
                    BrandModelsSeriesId = new Guid("e2f3b6c1-9c4d-4c88-86b8-7f92b1e4a6d2")
                },

                new BrandModels()
                {
                    Id = Guid.Parse("f1a7c0d4-35b2-4c88-8c9d-0a7e1f54b6d3"),
                    Name = "E60 M5",
                    ImageUrl = "https://www.secretentourage.com/wp-content/uploads/2014/12/cover.jpg",
                    yearProduced = 2010,
                    typeCoupe = "Sedan",
                    fuelType = "Petrol",
                    Engine = "5.0 V10 Naturally aspirated",
                    BrandModelsSeriesId = new Guid("c2f7d914-5b8a-4e3d-92b4-1af08c7e33a1")
                },

                new BrandModels()
                {
                    Id = Guid.Parse("9cbf2146-7c33-4a51-9f2c-41e7a4d92bb8"),
                    Name = "Mercedes-Benz C320",
                    ImageUrl = "https://i0.wp.com/bestsellingcarsblog.com/wp-content/uploads/2011/06/Mercedes-C-Class-Germany-2008.jpg?resize=600%2C344&ssl=1",
                    yearProduced = 2007,
                    typeCoupe = "Sedan",
                    fuelType = "Diesel",
                    Engine = "320 CDI",
                    BrandModelsSeriesId = new Guid("4a0dbf77-2e3a-4c1f-a1c9-3e2df59482b3")
                },

                new BrandModels()
                {
                    Id = Guid.Parse("0fa2e9d1-4e8b-4c76-bf33-9a2d6c107be9"),
                    Name = "Mercedes-Benz C63",
                    ImageUrl = "https://car-images.bauersecure.com/wp-images/12978/1mercedesc63amgdrive.jpg",
                    yearProduced = 2010,
                    typeCoupe = "Sedan",
                    fuelType = "Petrol",
                    Engine = "C63 AMG",
                    BrandModelsSeriesId = new Guid("4a0dbf77-2e3a-4c1f-a1c9-3e2df59482b3")
                },

                new BrandModels()
                {
                    Id = Guid.Parse("7de41fa8-1c26-4f3e-9d72-04c9fd8a33b7"),
                    Name = "Mercedes-Benz E320",
                    ImageUrl = "https://media.carsandbids.com/cdn-cgi/image/width=2080,quality=70/da4b9237bacccdf19c0760cab7aec4a8359010b0/photos/xlWuI-DUMXN2-2.0r28NUnna.jpg?t=161221805027",
                    yearProduced = 2008,
                    typeCoupe = "Sedan",
                    fuelType = "Diesel",
                    Engine = "320 CDI",
                    BrandModelsSeriesId = new Guid("a8c1f4eb-6b5a-4c9e-94df-1b3c7f8e2190")
                },

                new BrandModels()
                {
                    Id = Guid.Parse("82f7a4c9-53d9-4ef0-8c11-7b3fd95a2c10"),
                    Name = "Mercedes-Benz E550",
                    ImageUrl = "https://www.magnatuning.com/images/Mercedes-E-Class-W211-Exclusive-Body-Kit_picture_48790.jpg",
                    yearProduced = 2009,
                    typeCoupe = "Sedan",
                    fuelType = "Petrol",
                    Engine = "550 AMG",
                    BrandModelsSeriesId = new Guid("a8c1f4eb-6b5a-4c9e-94df-1b3c7f8e2190")
                },

                new BrandModels()
                {
                    Id = Guid.Parse("3bd17af4-9c81-4bcd-a0c0-251f7c8d9476"),
                    Name = "Audi A6 3.0",
                    ImageUrl = "https://7cars.bg/wp-content/uploads/2025/02/1-copy-1.jpg",
                    yearProduced = 2013,
                    typeCoupe = "Sedan",
                    fuelType = "Diesel",
                    Engine = "3.0 TDI",
                    BrandModelsSeriesId = new Guid("67f3c8d2-1af4-4e5d-9d10-8a3e72c6c4aa")
                },

                new BrandModels()
                {
                    Id = Guid.Parse("b2c4f8a3-ef52-4b98-9da2-38c1f4c7e212"),
                    Name = "Audi A6 3.0",
                    ImageUrl = "https://hips.hearstapps.com/hmg-prod/amv-prod-cad-assets/images/11q3/409394/2012-audi-a6-avant-tdi-diesel-review-car-and-driver-photo-411689-s-original.jpg?fill=1:1&resize=1200:*",
                    yearProduced = 2015,
                    typeCoupe = "Wagon",
                    fuelType = "Diesel",
                    Engine = "3.0 TDI",
                    BrandModelsSeriesId = new Guid("67f3c8d2-1af4-4e5d-9d10-8a3e72c6c4aa")
                },

                new BrandModels()
                {
                    Id = Guid.Parse("6a7fc1d9-325e-4a99-8b13-cdb42f75e610"),
                    Name = "Audi A8",
                    ImageUrl = "https://www.automobile-catalog.com/img/pictonorzw/audi/audi_a8070013_117.jpg",
                    yearProduced = 2007,
                    typeCoupe = "Sedan",
                    fuelType = "Diesel",
                    Engine = "3.0 TDI",
                    BrandModelsSeriesId = new Guid("d91ce0f5-7af1-4b78-a28e-f56e4c1c92bb")
                },

                new BrandModels()
                {
                    Id = Guid.Parse("c8f3d27a-14a0-4c8b-94b7-1fa9c4d5e3c2"),
                    Name = "Audi A8L",
                    ImageUrl = "https://www.netcarshow.com/Audi-A8_L-2008-Rear_Three-Quarter.970bbea1.jpg",
                    yearProduced = 2008,
                    typeCoupe = "Sedan",
                    fuelType = "Petrol",
                    Engine = "4.2 FSI V8",
                    BrandModelsSeriesId = new Guid("d91ce0f5-7af1-4b78-a28e-f56e4c1c92bb")
                },

                new BrandModels()
                {
                    Id = Guid.Parse("0d9e3f11-b78c-47fa-b1c5-a4c2f59d8e17"),
                    Name = "Porsche Panamera GTS",
                    ImageUrl = "https://smartcdn.gprod.postmedia.digital/driving/wp-content/uploads/2013/10/7607683.jpg",
                    yearProduced = 2012,
                    typeCoupe = "Sedan",
                    fuelType = "Petrol",
                    Engine = "4.8L V8",
                    BrandModelsSeriesId = new Guid("3b4f2a17-665d-43ee-bac8-0e3f4d92bb10")
                },

                new BrandModels()
                {
                    Id = Guid.Parse("e41b0c92-0fd2-49e3-a9cb-708e5d34b126"),
                    Name = "Porsche 911 Carrera S",
                    ImageUrl = "https://media.carsandbids.com/cdn-cgi/image/width=2080,quality=70/7a0a3c6148108c9c64425dd85e0181fa3cccb652/photos/vqhXN-hxQ.XHngqM4HaJ.jpg?t=161354154263",
                    yearProduced = 2006,
                    typeCoupe = "Coupe",
                    fuelType = "Petrol",
                    Engine = "3.8L",
                    BrandModelsSeriesId = new Guid("f88c3d66-2c44-4c84-9a55-64b1c385f7ae")
                }
            };
            return brandModels;
        }
    }
}
