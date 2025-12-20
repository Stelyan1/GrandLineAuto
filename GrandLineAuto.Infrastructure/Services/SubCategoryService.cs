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
    public class SubCategoryService : ISubCategoryService
    {
        private readonly IBaseRepository<SubCategory> _baserepository;

        public SubCategoryService(IBaseRepository<SubCategory> baseRepository)
        {
            _baserepository = baseRepository;
        }

        public async Task<IEnumerable<SubCategoryDTO>> GetSubCategoryBasedOnCategoryIdAndModelId(Guid categoryId, Guid modelId)
        {
            return await _baserepository.All()
                .Where(sc => sc.CategoryId == categoryId)
                .Where(sc => sc.Products.Any(p => p.BrandModelsProducts.Any(bmp => bmp.BrandModelId == modelId)))
                .Select(sc => new SubCategoryDTO
                {
                    Id = sc.Id,
                    Name = sc.Name,
                    ImageUrl = sc.ImageUrl,
                    CategoryId = categoryId,
                    Products = sc.Products
                }).ToListAsync();
        }
    }
}
