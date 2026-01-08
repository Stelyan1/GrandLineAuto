using GrandLineAuto.Data;
using GrandLineAuto.Data.Models;
using GrandLineAuto.Infrastructure.DTO_s;
using GrandLineAuto.Infrastructure.Services;
using GrandLineAuto.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GrandLineAuto.Api.Controllers
{
    [ApiController]
    [Route("api/brands")]
    public class BrandController : ControllerBase
    {
        private readonly GrandLineAutoDbContext _dbContext;

        public BrandController(GrandLineAutoDbContext dbContext)
        {
           _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<List<BrandDTO>>> GetAll([FromQuery] string? q = null, [FromQuery] int page = 1, [FromQuery] int pageSize = 20)
        {
            page = Math.Max(1, page);
            pageSize = Math.Clamp(pageSize, 1, 100);

            var query = _dbContext.Brands.AsNoTracking();

            if (!string.IsNullOrWhiteSpace(q))
            {
                query = query.Where(b => b.Name.Contains(q));
            }

            var brands = await query.OrderBy(b => b.Name).Skip((page - 1) * pageSize).Take(pageSize).Select(b => new BrandDTO
            {
               Id = b.Id,
               Name = b.Name,
               ImageUrl = b.ImageUrl
            })
            .ToListAsync();

            return Ok(brands);
        }
    }
}
