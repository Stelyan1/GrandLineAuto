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
        }
    }
}
