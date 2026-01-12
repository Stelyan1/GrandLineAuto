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
    public class CategoryServiceTests
    {
        private static GrandLineAutoDbContext CreateDbContext()
        {
            var options = new DbContextOptionsBuilder<GrandLineAutoDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new GrandLineAutoDbContext(options);
        }

        [Fact]
        public async Task GetCategoriesForGivenModel_WhenModelIsNotMatched()
        {
            //Arrange
            using var db = CreateDbContext();

            var modelId = Guid.NewGuid();

            db.AddRange(new Category
              {
                Id = Guid.NewGuid(), Name = "Braking System", ImageUrl = "sadasda", subCategories = new List<SubCategory>
                {
                    new SubCategory
                    {
                        Id = Guid.NewGuid(), Name = "dadsas", ImageUrl = "adfasd", Products = new List<Product> 
                        {
                            new Product 
                            {
                                Id = Guid.NewGuid(),
                                Name = "SDAD",
                                ImageUrl = "adads",
                                Description = "adasasd",
                                SpecificInfo1 = "dadasd",
                                SpecificInfo2 = "dadasd",
                                SpecificInfo3 = "dadasd",
                                SpecificInfo4 = "dadasd",
                                SpecificInfo5 = "dadasd",
                                SpecificInfo6 = "dadasd",
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
                }      
              }
                
            );

            await db.SaveChangesAsync();

            //Act

            var repo = new BaseRepository<Category>(db);

            var service = new CategoryService(repo);

            var result = (await service.GetCategoriesForGivenModel(Guid.NewGuid())).ToList();

            //Assert
            Xunit.Assert.Empty(result);
        }

        [Fact]
        public async Task GetCategoriesForGivenModel_WhenModelIdIsValid()
        {
            //Arrange
            using var db = CreateDbContext();

            var modelId = Guid.NewGuid();

            db.AddRange(
                new Category 
                { 
                    Id = Guid.NewGuid(), Name = "Braking System", ImageUrl = "adsasda", subCategories = new List<SubCategory>
                    {
                        new SubCategory
                        {
                            Id = Guid.NewGuid(),
                            Name = "Braking pads",
                            ImageUrl = "sdada",
                            Products = new List<Product>
                            {
                                new Product
                                {
                                    Id = Guid.NewGuid(),
                                    Name = "Brembo Xtra Line Pads",
                                    ImageUrl = "asdads",
                                    Description = "Description",
                                    SpecificInfo1 = "asd",
                                    SpecificInfo2 = "Description5",
                                    SpecificInfo3 = "Description6",
                                    SpecificInfo4 = "Description3",
                                    SpecificInfo5 = "Description2",
                                    SpecificInfo6 = "Description7",
                                    Price = 420,
                                    BrandModelsProducts = new List<BrandModelProductJoinTable>
                                    {
                                        new BrandModelProductJoinTable { BrandModelId = modelId }
                                    }
                                }
                            }
                        }
                    }
                }
            );

            await db.SaveChangesAsync();

            //Act

            var repo = new BaseRepository<Category>(db);

            var service = new CategoryService(repo);

            var result = (await service.GetCategoriesForGivenModel(modelId)).ToList();

            Xunit.Assert.Single(result);
        }
    }
}
