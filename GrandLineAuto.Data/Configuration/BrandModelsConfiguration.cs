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

            builder.Property(bm => bm.startProductionYear)
                   .IsRequired();

            builder.Property(bm => bm.endProductionYear)
                   .IsRequired();
        }
    }
}
