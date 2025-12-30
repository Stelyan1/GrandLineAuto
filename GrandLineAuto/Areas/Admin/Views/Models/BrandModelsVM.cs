using GrandLineAuto.Data.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GrandLineAuto.Areas.Admin.Views.Models
{
    public class BrandModelsVM
    {
        [Comment("Id for brand model")]
        public Guid Id { get; set; }

        [Comment("Name for given model")]
        public string Name { get; set; } = null!;

        [Comment("Image of the model")]
        public string ImageUrl { get; set; } = null!;

        [Comment("Year the car is produced")]
        public int yearProduced { get; set; }

        [Comment("Type of coupe")]
        public string typeCoupe { get; set; } = null!;

        [Comment("Fuel type")]
        public string fuelType { get; set; } = null!;

        [Comment("Engine")]
        public string Engine { get; set; } = null!;

        [Comment("Belongs to a serie")]
        public Guid BrandModelsSeriesId { get; set; }

        [Comment("Belongs to a serie")]
        public IEnumerable<SelectListItem> BrandModelSeries { get; set; } = new HashSet<SelectListItem>();

    }
}
