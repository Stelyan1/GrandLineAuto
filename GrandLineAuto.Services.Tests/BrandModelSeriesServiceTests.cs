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
    public class BrandModelSeriesServiceTests
    {
        private static GrandLineAutoDbContext CreateDbContext()
        {
            var options = new DbContextOptionsBuilder<GrandLineAutoDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;


            return new GrandLineAutoDbContext(options);
        }

        [Fact]
        public async Task GetEntityByBrandId_QueryReturn_BrandIdNull()
        {
            //Arrange

            using var db = CreateDbContext();

            var brandId = Guid.NewGuid();

            db.BrandModelsSeries.AddRange( new BrandModelsSeries { Id = Guid.NewGuid(), Name = "Mkms", ImageUrl = "sad", productionYears = "456-654", BrandId = brandId } );

            await db.SaveChangesAsync();

            //Act

            var repo = new BaseRepository<BrandModelsSeries>(db);

            var service = new BrandModelsSeriesService(repo);

            var result = (await service.GetEntityByBrandId(Guid.NewGuid()));

            //Assert

            Xunit.Assert.Empty(result);
        }

        [Fact]
        public async Task GetEntityByBrandId_QueryReturn_OnlyForThatBrandId()
        {
            //Arrange
            using var db = CreateDbContext();

            var brandId = Guid.NewGuid();
            var otherBrandId = Guid.NewGuid();

            db.BrandModelsSeries.AddRange(
                new BrandModelsSeries { Id = Guid.NewGuid(), Name = "BMW E9-3", ImageUrl = "asd", productionYears = "2045-2054", BrandId = brandId },
                new BrandModelsSeries { Id = Guid.NewGuid(), Name = "Mercedes-Benz E320", ImageUrl = "adadsf", productionYears = "2015-2023", BrandId = brandId },
                new BrandModelsSeries { Id = Guid.NewGuid(), Name = "Mercedes-Benz E550", ImageUrl = "adadsf", productionYears = "2015-2024", BrandId = otherBrandId }
                );

            await db.SaveChangesAsync();

            //Act
            var repo = new BaseRepository<BrandModelsSeries>(db);

            var service = new BrandModelsSeriesService(repo);

            var result = (await service.GetEntityByBrandId(brandId)).ToList();

            //Assert
            Xunit.Assert.Equal(2, result.Count);

            Xunit.Assert.All(result, x => Xunit.Assert.Equal(brandId, x.BrandId));
        }

        
    }
}
