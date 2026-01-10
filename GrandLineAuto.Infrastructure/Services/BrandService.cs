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
    public class BrandService : IBrandService
    {
        private readonly IBaseRepository<Brand> _baseRepository;

        public BrandService(IBaseRepository<Brand> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public async Task<IEnumerable<BrandDTO>> GetBrands(string? query)
        {
            var brands = _baseRepository.All().AsNoTracking();

            if (!string.IsNullOrWhiteSpace(query))
            {
                query = query.Trim();
                brands = brands.Where(b => b.Name.Contains(query));
            }


            return await brands.Select(b => new BrandDTO
            {
                Id = b.Id,
                Name = b.Name,
                ImageUrl = b.ImageUrl
            }).ToListAsync();
        }
    }
}
