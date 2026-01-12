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
    public class SubCategoryServiceTests
    {
        private static GrandLineAutoDbContext CreateDbContext()
        {
            var options = new DbContextOptionsBuilder<GrandLineAutoDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new GrandLineAutoDbContext(options);
        }

        [Fact]
        public async Task GetSubCategoryBasedOnCategoryIdAndModelId_WhenBothAreNotMatched()
        {
            //Arrange

            using var db = CreateDbContext();

            var modelId = Guid.NewGuid();

            var categoryId = Guid.NewGuid();

            db.AddRange( 
                new SubCategory
                {
                    Id = Guid.NewGuid(),
                    Name = "Braking Pads",
                    ImageUrl = "asdadas",
                    CategoryId = categoryId,
                    Products = new List<Product> 
                    { 
                        new Product 
                        {
                            Id = Guid.NewGuid(),
                            Name = "Varan",
                            ImageUrl = "sdadsa",
                            Description = "Description",
                            SpecificInfo1 = "adasd",
                            SpecificInfo2 = "adasd",
                            SpecificInfo3 = "adasd",
                            SpecificInfo4 = "adasd",
                            SpecificInfo5 = "adasd",
                            SpecificInfo6 = "adasd",
                            Price = 420,
                            BrandModelsProducts = new List<BrandModelProductJoinTable>
                            {
                                new BrandModelProductJoinTable
                                {
                                    BrandModelId = modelId
                                }
                            }
                        } 
                    }
                }
            );

            await db.SaveChangesAsync();

            //Act

            var repo = new BaseRepository<SubCategory>(db);

            var service = new SubCategoryService(repo);

            var result = (await service.GetSubCategoryBasedOnCategoryIdAndModelId(Guid.NewGuid(), Guid.NewGuid())).ToList();

            //Assert
            Xunit.Assert.Empty(result);

        }

        [Fact]
        public async Task GetSubCategoryBasedOnCategoryIdAndModelId_WhenBothAreFilled()
        {
            //Arrange

            using var db = CreateDbContext();

            var modelId = Guid.NewGuid();

            var categoryId = Guid.NewGuid();

            db.AddRange(
                new SubCategory
                {
                    Id = Guid.NewGuid(),
                    Name = "Braking Pads",
                    ImageUrl = "asdadas",
                    CategoryId = categoryId,
                    Products = new List<Product>
                    {
                        new Product
                        {
                            Id = Guid.NewGuid(),
                            Name = "Varan",
                            ImageUrl = "sdadsa",
                            Description = "Description",
                            SpecificInfo1 = "adasd",
                            SpecificInfo2 = "adasd",
                            SpecificInfo3 = "adasd",
                            SpecificInfo4 = "adasd",
                            SpecificInfo5 = "adasd",
                            SpecificInfo6 = "adasd",
                            Price = 420,
                            BrandModelsProducts = new List<BrandModelProductJoinTable>
                            {
                                new BrandModelProductJoinTable
                                {
                                    BrandModelId = modelId
                                }
                            }
                        }
                    }
                }
            );

            await db.SaveChangesAsync();

            //Act

            var repo = new BaseRepository<SubCategory>(db);

            var service = new SubCategoryService(repo);

            var result = (await service.GetSubCategoryBasedOnCategoryIdAndModelId(categoryId, modelId)).ToList();

            //Assert
            Xunit.Assert.Single(result);
        }
    }
}
