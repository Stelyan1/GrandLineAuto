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
    using static GrandLineAuto.Common.EntityValidation.BrandModelsSeries;
    public class BrandModelsSeriesConfiguration : IEntityTypeConfiguration<BrandModelsSeries>
    {
        public void Configure(EntityTypeBuilder<BrandModelsSeries> builder)
        {
            builder.HasKey(bms => bms.Id);

            builder.HasOne(bms => bms.Brand)
                   .WithMany(b => b.BrandModelsSeries)
                   .HasForeignKey(bms => bms.BrandId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.Property(bms => bms.Name)
                   .IsRequired()
                   .HasMaxLength(BrandModelsSeriesNameMaxLength);

            builder.Property(bms => bms.ImageUrl)
                   .IsRequired();

            builder.Property(bms => bms.productionYears)
                   .IsRequired()
                   .HasMaxLength(productionYearsMaxLength);

            builder.HasData(SeedBrandModelSeries());
        }

        private IEnumerable<BrandModelsSeries> SeedBrandModelSeries()
        {
            IEnumerable<BrandModelsSeries> brandModelsSeries = new List<BrandModelsSeries>()
            {
                new BrandModelsSeries()
                {
                   Id = Guid.Parse("e2f3b6c1-9c4d-4c88-86b8-7f92b1e4a6d2"),
                   Name = "BMW E90-3",
                   ImageUrl = "https://cdn3.focus.bg/autodata/i/bmw/3er/3er-e90/large/ef6298b9bf11a376c37eebb71bd96c77.jpg",
                   productionYears = "2004-2012",
                   BrandId = new Guid("3f6c9c77-4c1b-4d2b-9df2-1e8e4c27bba4")
                },

                new BrandModelsSeries()
                {
                    Id = Guid.Parse("c2f7d914-5b8a-4e3d-92b4-1af08c7e33a1"),
                    Name = "BMW E60-2",
                    ImageUrl = "https://cdn3.focus.bg/autodata/i/bmw/m5/m5-e60/large/20a25cb2b439604fe5db3c205f7e11b5.jpg",
                    productionYears = "2004-2010",
                    BrandId = new Guid("3f6c9c77-4c1b-4d2b-9df2-1e8e4c27bba4")
                },

                new BrandModelsSeries()
                {
                    Id = Guid.Parse("4a0dbf77-2e3a-4c1f-a1c9-3e2df59482b3"),
                    Name = "Mercedes-Benz C classe",
                    ImageUrl = "https://automoto.bg/listings/media/listing//1708102204_1708033948_1.jpg",
                    productionYears = "2006-2012",
                    BrandId = new Guid("9b2f1c3d-2f50-4c4c-b4ce-0f7d7f2c9f61")
                },

                new BrandModelsSeries()
                {
                    Id = Guid.Parse("a8c1f4eb-6b5a-4c9e-94df-1b3c7f8e2190"),
                    Name = "Mercedes-Benz E classe",
                    ImageUrl = "https://mobistatic3.focus.bg/mobile/photosorg/536/1/big//11755160806701536_rv.webp",
                    productionYears = "2005-2010",
                    BrandId = new Guid("9b2f1c3d-2f50-4c4c-b4ce-0f7d7f2c9f61")
                },

                new BrandModelsSeries()
                {
                    Id = Guid.Parse("67f3c8d2-1af4-4e5d-9d10-8a3e72c6c4aa"),
                    Name = "Audi A6 Serie",
                    ImageUrl = "https://images.ctfassets.net/uaddx06iwzdz/2KRO0CKDLDQnp38hfmbkpq/b63ce3731355495d119623ac742df6fc/audi-a6-l-01.jpg",
                    productionYears = "2011-2017",
                    BrandId = new Guid("c4c8a1c9-7c29-4d47-8c19-3e9d2ef0be55")
                },

                new BrandModelsSeries()
                {
                    Id = Guid.Parse("d91ce0f5-7af1-4b78-a28e-f56e4c1c92bb"),
                    Name = "Audi A8 Serie",
                    ImageUrl = "https://media.ed.edmunds-media.com/audi/a8/2008/oem/2008_audi_a8_sedan_l-quattro_fq_oem_2_1600.jpg",
                    productionYears = "2006-2010",
                    BrandId = new Guid("c4c8a1c9-7c29-4d47-8c19-3e9d2ef0be55")
                },

                new BrandModelsSeries()
                {
                    Id = Guid.Parse("3b4f2a17-665d-43ee-bac8-0e3f4d92bb10"),
                    Name = "Porsche Panamera",
                    ImageUrl = "https://media.drive.com.au/obj/tx_q:50,rs:auto:1920:1080:1/driveau/upload/cms/uploads/vdfiilc13rajkg86q3ps",
                    productionYears = "2009-2015",
                    BrandId = new Guid("0a7cb569-2e0e-4c76-a28e-92e3d355fa28")
                },

                new BrandModelsSeries()
                {
                    Id = Guid.Parse("f88c3d66-2c44-4c84-9a55-64b1c385f7ae"),
                    Name = "Porsche 911",
                    ImageUrl = "https://porschepictures.flowcenter.de/pmdb/thumbnail.cgi?id=252983&w=1935&h=1089&crop=1&public=1&cs=0e7eaa33c7c2d827",
                    productionYears = "2004-2012",
                    BrandId = new Guid("0a7cb569-2e0e-4c76-a28e-92e3d355fa28")
                }

            };
            return brandModelsSeries;
        }
    }
}
