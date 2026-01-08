using GrandLineAuto.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GrandLineAuto.Api.Controllers
{
    
    [ApiController]
    [Route("api/models/{modelId:guid}/categories")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
             _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategoryForModel([FromRoute] Guid modelId)
        {
            var categories = await _categoryService.GetCategoriesForGivenModel(modelId);

            return Ok(categories);
        }
    }
}
