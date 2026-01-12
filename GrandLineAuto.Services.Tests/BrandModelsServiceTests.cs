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
    public class BrandModelsServiceTests
    {
        private static GrandLineAutoDbContext CreateDbContext()
        {
            var options = new DbContextOptionsBuilder<GrandLineAutoDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new GrandLineAutoDbContext(options);
        }

        [Fact]
        public async Task GetBrandModelsBySeriesId_WhenSeriesIsNull()
        {
            //Arrange

            using var db = CreateDbContext();

            var seriesId = Guid.NewGuid();

            db.AddRange(
             new BrandModels
            {
                 Id = Guid.NewGuid(), Name = "dadad", ImageUrl = "afasd", Engine = "sdad", fuelType = "petrol", typeCoupe = "sdaasd", yearProduced = 2008, BrandModelsSeriesId = seriesId
            });

            await db.SaveChangesAsync();

            //Act

            var repo = new BaseRepository<BrandModels>(db);

            var service = new BrandModelsService(repo);

            var result = (await service.GetBrandModelsBySeriesId(Guid.NewGuid())).ToList();

            //Assert

            Xunit.Assert.Empty(result);
        }

        [Fact]
        public async Task GetBrandModelsBySeriesId_WhenThereIsSeriesId()
        {
            //Arrange

            using var db = CreateDbContext();

            var seriesId = Guid.NewGuid();

            var anotherSeriesId = Guid.NewGuid();

            db.AddRange(
             new BrandModels
            {
                 Id = Guid.NewGuid(), Name = "BMW-E93", ImageUrl = "asdadadad", Engine = "adaas", fuelType = "petrol", typeCoupe = "Sedan", yearProduced = 2008, BrandModelsSeriesId= seriesId
            },
             new BrandModels 
            {
                 Id = Guid.NewGuid(), Name = "BMW-G20", ImageUrl = "asdasdsad", Engine = "B58 6 liter", fuelType = "petrol", typeCoupe = "Sedan", yearProduced = 2020, BrandModelsSeriesId = seriesId
            },

             new BrandModels
             {
                 Id = Guid.NewGuid(), Name = "BMW-G22", ImageUrl = "asdasdsad", Engine = "B58 6 liter", fuelType = "petrol", typeCoupe = "Sedan", yearProduced = 2020, BrandModelsSeriesId = anotherSeriesId
             }
             );

            await db.SaveChangesAsync();

            //Act

            var repo = new BaseRepository<BrandModels>(db);

            var service = new BrandModelsService(repo);

            var result = (await service.GetBrandModelsBySeriesId(seriesId)).ToList();

            //Assert

            Xunit.Assert.Equal(2, result.Count);

            Xunit.Assert.All(result, x => Xunit.Assert.Equal(seriesId, x.BrandModelsSeriesId));
        }
        
    }
}
