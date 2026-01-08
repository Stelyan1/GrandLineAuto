using GrandLineAuto.Infrastructure.DTO_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrandLineAuto.Infrastructure.Services.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDTO>> GetProductForModelBySubCategoryId(Guid subcategoryId, Guid brandModelId);

        Task<IEnumerable<ProductDTO>> GetById(Guid productId);

        Task <ProductDTO?> DetailsProduct(Guid productId);

        
    }
}
