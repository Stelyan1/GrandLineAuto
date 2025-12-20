using GrandLineAuto.Data;
using GrandLineAuto.Infrastructure.Identity;
using GrandLineAuto.Infrastructure.Repositories;
using GrandLineAuto.Infrastructure.Repositories.Interfaces;
using GrandLineAuto.Infrastructure.Services;
using GrandLineAuto.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.EntityFrameworkCore;
using NPOI.SS.Formula.Functions;
using System.Threading.Tasks;

namespace GrandLineAuto
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<GrandLineAutoDbContext>(options =>
             options.UseSqlServer(builder.Configuration.GetConnectionString("SQLServer")));

            builder.Services.AddSingleton<IEmailSender, Infrastructure.Services.NoOpEmailSender>();

            // Add Identity Services
            builder.Services.AddIdentity<IdentityUser, IdentityRole>(cfg =>
            {
                cfg.Password.RequireDigit = true;

                cfg.Password.RequireLowercase = true;

                cfg.Password.RequireUppercase = true;

                cfg.Password.RequireNonAlphanumeric = false;

                cfg.Password.RequiredLength = 6;

                cfg.Password.RequiredUniqueChars = 0;

                cfg.SignIn.RequireConfirmedAccount = false;

                cfg.SignIn.RequireConfirmedPhoneNumber = false;

                cfg.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<GrandLineAutoDbContext>()
            .AddDefaultTokenProviders();

            builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            builder.Services.AddScoped(typeof(IBaseService<>), typeof(BaseService<>));

            builder.Services.AddScoped(typeof(IBrandModelsSeriesService), typeof(BrandModelsSeriesService));

            builder.Services.AddScoped(typeof(IBrandModelsService), typeof(BrandModelsService));

            builder.Services.AddRazorPages();
            
            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var config = services.GetRequiredService<IConfiguration>();

                await AdminInitializer.EnsureAdminAsync(services, config);
            }

                // Configure the HTTP request pipeline.
                if (!app.Environment.IsDevelopment())
                {
                    app.UseExceptionHandler("/Home/Error");
                    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                    app.UseHsts();
                }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            // Add Authorization and Authentication middleware
            app.UseAuthentication();
            app.UseAuthorization();

            // Enable Identity's Razor Pages for login, register
            app.MapRazorPages();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
