using GrandLineAuto.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace GrandLineAuto.Data
{
    public class GrandLineAutoDbContext : DbContext
    {
        public GrandLineAutoDbContext()
        {
            
        }

        public GrandLineAutoDbContext(DbContextOptions options) : base (options)
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
