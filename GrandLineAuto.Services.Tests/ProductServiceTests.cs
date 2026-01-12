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
    public class ProductServiceTests
    {
        private static GrandLineAutoDbContext CreateDbContext()
        {
            var options = new DbContextOptionsBuilder<GrandLineAutoDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            return new GrandLineAutoDbContext(options);
        }

        [Fact]
        public async Task GetProductForModelBySubCategoryId_WhenAreNotMatched()
        {
            //Arrange
            using var db = CreateDbContext();

            var subCategoryId = Guid.NewGuid();

            var modelId = Guid.NewGuid();

            db.AddRange( 
                new Product 
                {
                    Id = Guid.NewGuid(),
                    Name = "Brembo Pds",
                    ImageUrl = "adasdasd",
                    Description = "Description",
                    SpecificInfo1 = "adasd",
                    SpecificInfo2 = "adasd",
                    SpecificInfo3 = "adasd",
                    SpecificInfo4 = "adasd",
                    SpecificInfo5 = "adasd",
                    SpecificInfo6 = "adasd",
                    Price = 550,
                    SubCategoryId = subCategoryId,
                    BrandModelsProducts = new List <BrandModelProductJoinTable>
                    {
                        new BrandModelProductJoinTable
                        {
                            BrandModelId = modelId
                        }
                    }
                }
            );

            await db.SaveChangesAsync();

            //Act

            var repo = new BaseRepository<Product>(db);

            var service = new ProductService(repo);

            var result = (await service.GetProductForModelBySubCategoryId(Guid.NewGuid(), Guid.NewGuid())).ToList();

            //Assert

            Xunit.Assert.Empty(result);
        }


        [Fact]
        public async Task GetProductForModelBySubCategoryId_WhenAreFilled()
        {
            //Arrange
            using var db = CreateDbContext();

            var subCategoryId = Guid.NewGuid();

            var otherSubCatId = Guid.NewGuid();

            var modelId = Guid.NewGuid();

            var otherModelId = Guid.NewGuid();

            db.AddRange(
                new Product
                {
                    Id = Guid.NewGuid(),
                    Name = "Brembo Pds",
                    ImageUrl = "adasdasd",
                    Description = "Description",
                    SpecificInfo1 = "adasd",
                    SpecificInfo2 = "adasd",
                    SpecificInfo3 = "adasd",
                    SpecificInfo4 = "adasd",
                    SpecificInfo5 = "adasd",
                    SpecificInfo6 = "adasd",
                    Price = 550,
                    SubCategoryId = subCategoryId,
                    BrandModelsProducts = new List<BrandModelProductJoinTable>
                    {
                        new BrandModelProductJoinTable
                        {
                            BrandModelId = modelId
                        }
                    }
                }
            );

            await db.SaveChangesAsync();

            //Act

            var repo = new BaseRepository<Product>(db);

            var service = new ProductService(repo);

            var result = (await service.GetProductForModelBySubCategoryId(subCategoryId, modelId)).ToList();

            //Assert

            Xunit.Assert.Single(result);
        }

        [Fact]
        public async Task GetById_ByProductId_WhenNotMatched()
        {
            using var db = CreateDbContext();

            var productId = Guid.NewGuid();

            db.AddRange(
             new Product
             {
                 Id = productId,
                 Name = "Brembo Pds",
                 ImageUrl = "adasdasd",
                 Description = "Description",
                 SpecificInfo1 = "adasd",
                 SpecificInfo2 = "adasd",
                 SpecificInfo3 = "adasd",
                 SpecificInfo4 = "adasd",
                 SpecificInfo5 = "adasd",
                 SpecificInfo6 = "adasd",
                 Price = 550
             }   
            );

            await db.SaveChangesAsync();

            var repo = new BaseRepository<Product>(db);

            var service = new ProductService(repo);

            var result = (await service.GetById(Guid.NewGuid())).ToList();

            Xunit.Assert.Empty(result);
        }

        [Fact]
        public async Task GetById_ByProductId_WhenFilled()
        {
            using var db = CreateDbContext();

            var productId = Guid.NewGuid();

            db.AddRange(
             new Product
             {
                 Id = productId,
                 Name = "Brembo Pds",
                 ImageUrl = "adasdasd",
                 Description = "Description",
                 SpecificInfo1 = "adasd",
                 SpecificInfo2 = "adasd",
                 SpecificInfo3 = "adasd",
                 SpecificInfo4 = "adasd",
                 SpecificInfo5 = "adasd",
                 SpecificInfo6 = "adasd",
                 Price = 550
             }
            );

            await db.SaveChangesAsync();

            var repo = new BaseRepository<Product>(db);

            var service = new ProductService(repo);

            var result = (await service.GetById(productId)).ToList();

            Xunit.Assert.Single(result);
        }

        [Fact]
        public async Task DetailsProduct_ByProductId_WhenNotMatched()
        {
            using var db = CreateDbContext();

            var productId = Guid.NewGuid();

            db.AddRange(
             new Product
             {
                 Id = productId,
                 Name = "Brembo Pdsss",
                 ImageUrl = "adasdasd",
                 Description = "Description",
                 SpecificInfo1 = "adasd",
                 SpecificInfo2 = "adasd",
                 SpecificInfo3 = "adasd",
                 SpecificInfo4 = "adasd",
                 SpecificInfo5 = "adasd",
                 SpecificInfo6 = "adasd",
                 Price = 560
             }
            );

            await db.SaveChangesAsync();

            var repo = new BaseRepository<Product>(db);

            var service = new ProductService(repo);

            var result = (await service.DetailsProduct(Guid.NewGuid()));

            Xunit.Assert.Null(result);
        }

        [Fact]
        public async Task DetailsProduct_ByProductId_WhenFilled()
        {
            using var db = CreateDbContext();

            var productId = Guid.NewGuid();

            db.AddRange(
             new Product
             {
                 Id = productId,
                 Name = "Brembo Pdsss",
                 ImageUrl = "adasdasd",
                 Description = "Description",
                 SpecificInfo1 = "adasd",
                 SpecificInfo2 = "adasd",
                 SpecificInfo3 = "adasd",
                 SpecificInfo4 = "adasd",
                 SpecificInfo5 = "adasd",
                 SpecificInfo6 = "adasd",
                 Price = 560
             }
            );

            await db.SaveChangesAsync();

            var repo = new BaseRepository<Product>(db);

            var service = new ProductService(repo);

            var result = (await service.DetailsProduct(productId));

            Xunit.Assert.NotNull(result);

            Xunit.Assert.Equal(productId, result!.Id);

        }
    }
}
