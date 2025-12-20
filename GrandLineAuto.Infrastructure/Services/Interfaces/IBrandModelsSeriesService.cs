using GrandLineAuto.Infrastructure.DTO_s;
using NPOI.SS.Formula.Functions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandLineAuto.Infrastructure.Services.Interfaces
{
    public interface IBrandModelsSeriesService
    {
        Task<IEnumerable<BrandModelSeriesDTO>> GetEntityByBrandId(Guid brandId);
    }
}
