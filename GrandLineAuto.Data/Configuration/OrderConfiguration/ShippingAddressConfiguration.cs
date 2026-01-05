using GrandLineAuto.Data.Models.OrderEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandLineAuto.Data.Configuration.OrderConfiguration
{
    public class ShippingAddressConfiguration : IEntityTypeConfiguration<ShippingAddress>
    {
        public void Configure(EntityTypeBuilder<ShippingAddress> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.FullName).HasMaxLength(100).IsRequired();
            builder.Property(a => a.Phone).HasMaxLength(20).IsRequired();
            builder.Property(a => a.AddressLine1).HasMaxLength(200).IsRequired();
            builder.Property(a => a.AddressLine2).HasMaxLength(200);
            builder.Property(a => a.City).HasMaxLength(80).IsRequired();
            builder.Property(a => a.PostalCode).HasMaxLength(20);
            builder.Property(a => a.Country).HasMaxLength(80).IsRequired();
        }
    }
}
