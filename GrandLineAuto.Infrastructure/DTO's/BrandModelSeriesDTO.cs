using GrandLineAuto.Data.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandLineAuto.Infrastructure.DTO_s
{
    public class BrandModelSeriesDTO
    {
        [Comment("Identifier of Series")]
        public Guid Id { get; set; }

        [Comment("Name of Series")]
        public string Name { get; set; } = null!;

        [Comment("Image of Series")]
        public string ImageUrl { get; set; } = null!;

        [Comment("Year of the Series")]
        public string productionYears { get; set; } = null!;

        [Comment("Identifier to belonged brand")]
        public Guid BrandId { get; set; }
        [Comment("Belongs to a brand")]
        public Brand Brand { get; set; } = null!;

        public IEnumerable<SelectListItem> Brands { get; set; } = Enumerable.Empty<SelectListItem>();

        public ICollection<BrandModels> BrandModels { get; set; } = new HashSet<BrandModels>();
    }
}
