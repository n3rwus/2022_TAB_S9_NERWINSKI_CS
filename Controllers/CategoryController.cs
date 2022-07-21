using Microsoft.AspNetCore.Mvc;
using WebAlbum.Models.Categories;
using WebAlbum.Services;


namespace WebAlbum.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost("AddTag")]
        public IActionResult AddTag(AddCategoryRequest request)
        {
            var result = _categoryService.AddTag(request);

            if (result != null) return Ok();
            else return BadRequest();
        }

        [HttpPost("GetTags")]
        public IActionResult GetTags(GetCategoryRequest request)
        {
            var result = _categoryService.GetTags(request);

            if (result != null) return Ok(result);
            else return NotFound();
        }

        [HttpPost("DeleteTag")]
        public IActionResult DeleteTag(DeleteCategoryRequest request)
        {
            var result = _categoryService.DeleteTag(request);

            if (result != null) return Ok();
            else return NotFound();
        }
    }
}
