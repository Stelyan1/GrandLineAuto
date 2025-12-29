using GrandLineAuto.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandLineAuto.Infrastructure.DTO_s
{
    public class BrandDTO
    {
        [Comment("Id for brand")]
        public Guid Id { get; set; }

        [Comment("Name of brand")]
        public string Name { get; set; } = null!;

        [Comment("Image for logo")]
        public string ImageUrl { get; set; } = null!;
        [Comment("Brand can have a lot of series")]
        public ICollection<BrandModelsSeries> BrandModelsSeries { get; set; } = new HashSet<BrandModelsSeries>();
    }
}
