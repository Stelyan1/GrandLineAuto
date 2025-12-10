using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandLineAuto.Data.Models
{
    public class BrandModels
    {
        [Comment("Id for brand model")]
        public Guid Id { get; set; }

        [Comment("Name for given model")]
        public string Name { get; set; } = null!;

        [Comment("Image of the model")]
        public string ImageUrl { get; set; } = null!;

        [Comment("Started producing")]
        public int startProductionYear { get; set; }

        [Comment("Ended producing")]
        public int endProductionYear { get; set; }

        [Comment("Belongs to a serie")]
        public Guid BrandModelsSeriesId { get; set; }

        [Comment("Belongs to a serie")]
        public BrandModelsSeries BrandModelsSeries { get; set; } = null!;
    }
}
