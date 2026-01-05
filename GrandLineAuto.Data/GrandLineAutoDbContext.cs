using GrandLineAuto.Data.Configuration;
using GrandLineAuto.Data.Configuration.CartConfiguration;
using GrandLineAuto.Data.Configuration.OrderConfiguration;
using GrandLineAuto.Data.Configuration.UserConfiguration;
using GrandLineAuto.Data.Models;
using GrandLineAuto.Data.Models.CartEntities;
using GrandLineAuto.Data.Models.OrderEntities;
using GrandLineAuto.Data.Models.UserEntities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace GrandLineAuto.Data
{
    public class GrandLineAutoDbContext : IdentityDbContext<IdentityUser>
    {
        public GrandLineAutoDbContext(DbContextOptions<GrandLineAutoDbContext> options) : base (options)
        {
            
        }

        public virtual DbSet<Brand> Brands { get; set; } = null!;
        public virtual DbSet<BrandModelsSeries> BrandModelsSeries { get; set; } = null!;
        public virtual DbSet<BrandModels> BrandModels { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<SubCategory> SubCategories { get; set; } = null!;
        public virtual DbSet<ProductManufacturer> ProductManufacturers { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<BrandModelProductJoinTable> BrandModelProductJoinTables { get; set; } = null!;
        public virtual DbSet<UserProfile> UserProfiles { get; set; } = null!;
        public virtual DbSet<ApplicationUser> ApplicationUsers { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderItem> OrderItems  { get; set; } = null!;
        public virtual DbSet<ShippingAddress> ShippingAddresses { get; set; } = null!;
        public virtual DbSet<CartItem> CartItems { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.ApplyConfiguration(new ApplicationUserConfiguration());
            modelBuilder.ApplyConfiguration(new UserProfileConfiguration());

            modelBuilder.ApplyConfiguration(new OrderConfiguration());
            modelBuilder.ApplyConfiguration(new OrderItemConfiguration());
            modelBuilder.ApplyConfiguration(new ShippingAddressConfiguration());
            modelBuilder.ApplyConfiguration(new CartItemConfiguration());
        }
    }
}
