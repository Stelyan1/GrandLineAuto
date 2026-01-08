using GrandLineAuto.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GrandLineAuto.Api.Controllers
{
    
    [ApiController]
    [Route("api")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("subcategories/{subCategoryId:guid}/models/{modelId:guid}/products")]
        public async Task<IActionResult> GetProductsBySubCategoryIdAndModelId([FromRoute] Guid subCategoryId, [FromRoute] Guid modelId)
        {
            var product = await _productService.GetProductForModelBySubCategoryId(subCategoryId, modelId);

            return Ok(product);
        }

        [HttpGet("products/{productId:guid}")]
        public async Task<IActionResult> ProductDetails([FromRoute] Guid productId)
        {
            var product = await _productService.DetailsProduct(productId);

            return Ok(product);
        }
    }
}
