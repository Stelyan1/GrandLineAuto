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
    public class BrandModelsService : IBrandModelsService
    {
        private readonly IBaseRepository<BrandModels> _brandModels;

        public BrandModelsService(IBaseRepository<BrandModels> brandModels)
        {
            _brandModels = brandModels;
        }

        public async Task<IEnumerable<BrandModelsDTO>> GetBrandModelsBySeriesId(Guid seriesId)
        {
            return await _brandModels.All().Where(bm => bm.BrandModelsSeriesId == seriesId).Select(bm => new BrandModelsDTO
            {
                Id = bm.Id,
                Name = bm.Name,
                ImageUrl = bm.ImageUrl,
                yearProduced = bm.yearProduced,
                typeCoupe = bm.typeCoupe,
                fuelType = bm.fuelType,
                Engine = bm.Engine,
                BrandModelsSeriesId = bm.BrandModelsSeriesId,
                BrandModelsProducts = bm.BrandModelsProducts
            }).ToListAsync();
        }
    }
}
