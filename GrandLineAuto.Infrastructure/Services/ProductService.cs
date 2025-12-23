using GrandLineAuto.Data.Models;
using GrandLineAuto.Infrastructure.DTO_s;
using GrandLineAuto.Infrastructure.Repositories.Interfaces;
using GrandLineAuto.Infrastructure.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandLineAuto.Infrastructure.Services
{
    public class ProductService : IProductService
    {
        private readonly IBaseRepository<Product> _baserepository;

        public ProductService(IBaseRepository<Product> baseRepository)
        {
            _baserepository = baseRepository;
        }

        public async Task<ProductDTO?> DetailsProduct(Guid productId)
        {
            return await _baserepository.AllForGivenEntity<Product>().Where(p => p.Id == productId).Select(p => new ProductDTO
            {
                Id = p.Id,
                Name = p.Name,
                ImageUrl = p.ImageUrl,
                SpecificInfo1 = p.SpecificInfo1,
                SpecificInfo2 = p.SpecificInfo2,
                SpecificInfo3 = p.SpecificInfo3,
                SpecificInfo4 = p.SpecificInfo4,
                SpecificInfo5 = p.SpecificInfo5,
                SpecificInfo6 = p.SpecificInfo6,
                Description = p.Description,
                Price = p.Price,
                SubCategoryId = p.SubCategoryId,
                BrandModelsProducts = p.BrandModelsProducts
            }).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ProductDTO>> GetById(Guid productId)
        {
            return await _baserepository.All().Where(p => p.Id == productId).Select(p => new ProductDTO
            {
                Id = p.Id,
                Name = p.Name,
                ImageUrl = p.ImageUrl,
                SpecificInfo1 = p.SpecificInfo1,
                SpecificInfo2 = p.SpecificInfo2,
                SpecificInfo3 = p.SpecificInfo3,
                SpecificInfo4 = p.SpecificInfo4,
                SpecificInfo5 = p.SpecificInfo5,
                SpecificInfo6 = p.SpecificInfo6,
                Description = p.Description,
                Price = p.Price,
                SubCategoryId = p.SubCategoryId,
                BrandModelsProducts = p.BrandModelsProducts
            }).ToListAsync();
        }

       

        public async Task<IEnumerable<ProductDTO>> GetProductForModelBySubCategoryId(Guid subcategoryId)
        {
            return await _baserepository.All().Where(p => p.SubCategoryId == subcategoryId).Select(p => new ProductDTO
            {
                Id = p.Id,
                Name = p.Name,
                ImageUrl = p.ImageUrl,
                SpecificInfo1 = p.SpecificInfo1,
                SpecificInfo2 = p.SpecificInfo2,
                SpecificInfo3 = p.SpecificInfo3,
                SpecificInfo4 = p.SpecificInfo4,
                SpecificInfo5 = p.SpecificInfo5,
                SpecificInfo6 = p.SpecificInfo6,
                Description = p.Description,
                Price = p.Price,
                SubCategoryId = p.SubCategoryId,
                BrandModelsProducts = p.BrandModelsProducts
            }).ToListAsync();
        }
    }
}
