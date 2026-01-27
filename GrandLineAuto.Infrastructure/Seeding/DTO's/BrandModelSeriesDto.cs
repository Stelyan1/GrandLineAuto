using GrandLineAuto.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandLineAuto.Infrastructure.Seeding.DTO_s
{
    public class BrandModelSeriesDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public string ImageUrl { get; set; } = null!;

        public string productionYears { get; set; } = null!;

        public Guid BrandId { get; set; }
        public Brand Brand { get; set; } = null!;
    }
}
