using Microsoft.EntityFrameworkCore;

namespace GrandLineAuto.Areas.Admin.Views.Models
{
    public class ProductManufacturerVM
    {
        [Comment("Identifier of manufacturer")]
        public Guid Id { get; set; }

        [Comment("Name of the manufacturer")]
        public string Name { get; set; } = null!;
    }
}
