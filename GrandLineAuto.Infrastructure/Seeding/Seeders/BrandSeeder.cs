using GrandLineAuto.Data;
using GrandLineAuto.Data.Models;
using GrandLineAuto.Infrastructure.DTO_s;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GrandLineAuto.Infrastructure.Seeding.Seeders
{
    public class BrandSeeder
    {
        private readonly GrandLineAutoDbContext _dbContext;

        public BrandSeeder(GrandLineAutoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task SeedAsync(string seedRootPath)
        {
            var filePath = Path.Combine(seedRootPath, "brands.json");

            if (!File.Exists(filePath)) return;

            var json = await File.ReadAllTextAsync(filePath);

            var brands = JsonSerializer.Deserialize<List<BrandDTO>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            });

            if (brands == null || brands.Count == 0) return;

            foreach (var dto in brands)
            {
                var existing = await _dbContext.Brands.FirstOrDefaultAsync(b => b.Name == dto.Name);

                if (existing == null)
                {
                    var brand = new Brand
                    {
                        Id = dto.Id,
                        Name = dto.Name,
                        ImageUrl = dto.ImageUrl
                    };

                    await _dbContext.Brands.AddAsync(brand);
                }
                else
                {
                    existing.ImageUrl = dto.ImageUrl;
                }

                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
