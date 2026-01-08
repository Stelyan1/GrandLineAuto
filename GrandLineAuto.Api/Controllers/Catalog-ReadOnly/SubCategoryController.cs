using GrandLineAuto.Infrastructure.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GrandLineAuto.Api.Controllers
{
   
    [ApiController]
    [Route("api/models/{modelId:guid}/categories/{categoryId:guid}/subcategories")]
    public class SubCategoryController : ControllerBase
    {
        private readonly ISubCategoryService _subCategoryService;

        public SubCategoryController(ISubCategoryService subCategoryService)
        {
            _subCategoryService = subCategoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetSubCategoryByModelIdandCategoryId([FromRoute] Guid modelId,[FromRoute] Guid categoryId)
        {
            var subCategory = await _subCategoryService.GetSubCategoryBasedOnCategoryIdAndModelId(categoryId, modelId);

            return Ok(subCategory);
        }
    }
}
