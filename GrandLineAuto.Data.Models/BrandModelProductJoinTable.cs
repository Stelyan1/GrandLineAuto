using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandLineAuto.Data.Models
{
    public class BrandModelProductJoinTable
    {
        [Comment("Mapping to brand model")]
        public Guid BrandModelId { get; set; }
        public BrandModels BrandModels { get; set; } = null!;

        [Comment("Mapping to product")]
        public Guid ProductId { get; set; }
        public Product Products { get; set; } = null!;
    }
}
