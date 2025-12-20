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
    public class CategoryService : ICategoryService
    {
        private readonly IBaseRepository<Category> _categoryRepo;

        public CategoryService(IBaseRepository<Category> categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategoriesForGivenModel(Guid modelId)
        {
            return await _categoryRepo.All()
                .Where(c => c.subCategories.Any(sc => sc.Products.Any(p => p.BrandModelsProducts.Any(bmp => bmp.BrandModelId == modelId))))
                .Select(c => new CategoryDTO
                {
                    Id = c.Id,
                    Name = c.Name,
                    ImageUrl = c.ImageUrl,
                    subCategories = c.subCategories
                }).ToListAsync();
        }
    }
}
