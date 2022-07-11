using Microsoft.AspNetCore.Mvc;
using WebAlbum.Authorization;
using WebAlbum.Entities;
using WebAlbum.Models.Categores.Request;
using WebAlbum.Models.Categores.Response;
using WebAlbum.Services;

namespace WebAlbum.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CategorysController : BaseController
    {
        private readonly ICategoryService _categoryService;

        public CategorysController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CategoryResponse>> GetAll()
        {
            var categories = _categoryService.GetAll();
            return Ok(categories);
        }

        [HttpGet("{id:int}")]
        public ActionResult<CategoryResponse> GetById(int id)
        {
            var category = _categoryService.GetById(id);
            return Ok(category);
        }

        [HttpPut("{id:int}")]
        public ActionResult<CategoryResponse> Update(int id, UpdateCategoryRequest model)
        {
            var category = _categoryService.Update(id, model);
            return Ok(category);
        }

        [HttpPost]
        public ActionResult<CategoryResponse> Create(CreateCategoryRequest model)
        {
            var category = _categoryService.Create(model);
            return Ok(category);
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            // users can delete their own Category

            _categoryService.Delete(id);
            return Ok(new { message = "Category deleted successfully" });
        }
    }
}
