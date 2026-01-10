using GrandLineAuto.Data;
using GrandLineAuto.Data.Models;
using GrandLineAuto.Infrastructure.Repositories;
using GrandLineAuto.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GrandLineAuto.Services.Tests
{
    public class BrandServiceTests
    {
        private static GrandLineAutoDbContext CreateDbContext()
        {
            var options = new DbContextOptionsBuilder<GrandLineAutoDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new GrandLineAutoDbContext(options);
        }


        [Fact]
        public async Task GetBrands_WhenQueryIsNull_ReturnsAllMapped()
        {
            //Arrange 
            using var db = CreateDbContext();

            db.Brands.AddRange(
                new Brand { Id = Guid.NewGuid(), Name = "BMW", ImageUrl = "asdad" },
                new Brand { Id = Guid.NewGuid(), Name = "Mercedes-Benz", ImageUrl = "asdsad" }
            );

            await db.SaveChangesAsync();

            var repo = new BaseRepository<Brand>(db);
            var service = new BrandService(repo);

            var result = (await service.GetBrands(null)).ToList();

            Xunit.Assert.Equal(2, result.Count);
        }

        [Fact]
        public async Task GetBrands_WhenQueryMatches_ReturnsFiltered()
        {
            using var db = CreateDbContext();

            db.Brands.AddRange(new Brand
            {
                Id = Guid.NewGuid(),
                Name = "BMW",
                ImageUrl = "asda"
            },

            new Brand
            {
                Id = Guid.NewGuid(),
                Name = "Mercedes-Benz",
                ImageUrl = "adfsfa"
            });
            await db.SaveChangesAsync();

            var repo = new BaseRepository<Brand>(db);
            var service = new BrandService(repo);

            var result = (await service.GetBrands("BMW")).ToList();

            Xunit.Assert.Single(result);
            Xunit.Assert.Equal("BMW", result[0].Name);
        }
    }
}
