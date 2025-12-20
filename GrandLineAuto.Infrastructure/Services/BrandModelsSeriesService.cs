using GrandLineAuto.Data.Models;
using GrandLineAuto.Infrastructure.DTO_s;
using GrandLineAuto.Infrastructure.Repositories.Interfaces;
using GrandLineAuto.Infrastructure.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandLineAuto.Infrastructure.Services
{
    public class BrandModelsSeriesService : IBrandModelsSeriesService
    {
        private readonly IBaseRepository<BrandModelsSeries> _brandModelsSeries;

        public BrandModelsSeriesService(IBaseRepository<BrandModelsSeries> brandModelsSeries)
        {
            _brandModelsSeries = brandModelsSeries;
        }

        public async Task<IEnumerable<BrandModelSeriesDTO>> GetEntityByBrandId(Guid brandId)
        {
            return await _brandModelsSeries.All()
                .Where(bms => bms.BrandId == brandId)
                .Select(bms => new BrandModelSeriesDTO
                {
                 Id = bms.Id,
                 Name = bms.Name,
                 ImageUrl = bms.ImageUrl,
                 productionYears = bms.productionYears,
                 BrandId = bms.BrandId,
                 BrandModels = bms.BrandModels
                }).ToListAsync();
        }
    }
}
