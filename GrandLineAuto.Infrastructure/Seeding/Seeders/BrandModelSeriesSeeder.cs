using GrandLineAuto.Data;
using GrandLineAuto.Data.Models;
using GrandLineAuto.Infrastructure.DTO_s;
using GrandLineAuto.Infrastructure.Seeding.DTO_s;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GrandLineAuto.Infrastructure.Seeding.Seeders
{
    public class BrandModelSeriesSeeder
    {
        private readonly GrandLineAutoDbContext _dbContext;

        public BrandModelSeriesSeeder(GrandLineAutoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task SeedAsync(string seedRootPath)
        {
            var filePath = Path.Combine(seedRootPath, "brandModelSeries.json");

            if (!File.Exists(filePath)) return;

            var json = await File.ReadAllTextAsync(filePath);

            var bmsDto = JsonSerializer.Deserialize<List<BrandModelSeriesDto>>(json, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
            });

            if (bmsDto == null || bmsDto.Count == 0) return;

            foreach (var bDto in bmsDto)
            {
                var existingBrand = await _dbContext.Brands.AnyAsync(b => b.Id == bDto.BrandId);

                if (!existingBrand) throw new Exception("Given brand doesn't exists");

                var exists = await _dbContext.BrandModelsSeries.AnyAsync(bms => bms.BrandId == bDto.BrandId && bms.Name == bDto.Name);

                if (!exists) 
                {
                    _dbContext.BrandModelsSeries.Add(new BrandModelsSeries
                    {
                        Id = bDto.Id,
                        Name = bDto.Name,
                        ImageUrl = bDto.ImageUrl,
                        productionYears = bDto.productionYears,
                        BrandId = bDto.BrandId
                    });
                }
            }

            await _dbContext.SaveChangesAsync();
        }
    }
}
