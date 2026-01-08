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
    using static GrandLineAuto.Common.EntityValidation.OrderItem;
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(i => i.UnitPrice)
                   .HasPrecision(18, 2);

            builder.Property(i => i.ProductName)
                   .HasMaxLength(ProductNameMaxLength)
                   .IsRequired();

            builder.HasOne(i => i.Product)
                   .WithMany()
                   .HasForeignKey(i => i.ProductId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
