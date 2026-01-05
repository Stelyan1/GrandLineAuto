using GrandLineAuto.Data.Models.UserEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandLineAuto.Data.Configuration.UserConfiguration
{
    public class UserProfileConfiguration : IEntityTypeConfiguration<UserProfile>
    {
        public void Configure(EntityTypeBuilder<UserProfile> builder)
        {
            builder.HasKey(up => up.Id);

            builder.Property(up => up.FirstName)
                .IsRequired()
                .HasMaxLength(60);

            builder.Property(up => up.LastName)
                .IsRequired()
                .HasMaxLength(60);

            builder.Property(up => up.Phone)
                .HasMaxLength(60);

            builder.Property(up => up.DefaultAddress)
                .HasMaxLength(120);

            builder.Property(up => up.City)
                .HasMaxLength(120);
        }
    }
}
