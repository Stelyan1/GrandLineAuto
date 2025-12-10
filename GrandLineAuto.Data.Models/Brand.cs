using Microsoft.EntityFrameworkCore;

namespace GrandLineAuto.Data.Models
{
    public class Brand
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
