
using GrandLineAuto.Data;
using GrandLineAuto.Infrastructure.Repositories;
using GrandLineAuto.Infrastructure.Repositories.Interfaces;
using GrandLineAuto.Infrastructure.Repositories.Purchasing;
using GrandLineAuto.Infrastructure.Repositories.Purchasing.Interfaces;
using GrandLineAuto.Infrastructure.Services;
using GrandLineAuto.Infrastructure.Services.Interfaces;
using GrandLineAuto.Infrastructure.Services.Purchasing;
using GrandLineAuto.Infrastructure.Services.Purchasing.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GrandLineAuto.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            //DB
            builder.Services.AddDbContext<GrandLineAutoDbContext>(opt =>
            {
                opt.UseSqlServer(builder.Configuration.GetConnectionString("SQLServer"));
            });

            builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            builder.Services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));

            builder.Services.AddScoped(typeof(IBrandModelsSeriesService), typeof(BrandModelsSeriesService));

            builder.Services.AddScoped(typeof(IBrandModelsService), typeof(BrandModelsService));

            builder.Services.AddScoped(typeof(ICategoryService), typeof(CategoryService));

            builder.Services.AddScoped(typeof(ISubCategoryService), typeof(SubCategoryService));

            builder.Services.AddScoped(typeof(IProductService), typeof(ProductService));

            builder.Services.AddScoped(typeof(ICartRepository), typeof(CartRepository));

            builder.Services.AddScoped(typeof(IOrderRepository), typeof(OrderRepository));

            builder.Services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));

            builder.Services.AddScoped(typeof(ICartService), typeof(CartService));

            builder.Services.AddScoped(typeof(IOrderService), typeof(OrderService));

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
