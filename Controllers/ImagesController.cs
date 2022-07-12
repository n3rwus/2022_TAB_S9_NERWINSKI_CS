using WebAlbum.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAlbum.Entities;
using WebAlbum.Models.Images.Request;
using WebAlbum.Models.Images.Response;
using WebAlbum.Services;

namespace WebAlbum.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class ImagesController : BaseController
    {
        private readonly IImageService _imageService;
        public ImagesController(IImageService imageService)
        {
            _imageService = imageService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ImageResponse>> GetAll()
        {
            var images = _imageService.GetAll();
            return Ok(images);
        }

        [HttpGet("{id:int}")]
        public ActionResult<ImageResponse> GetById(int id)
        {
            if (id != Account.Id)
                return Unauthorized(new {message = "Unauthorized" });

            var image = _imageService.GetById(id);
            return Ok(image);
        }

        [HttpPut("{id:int}")]
        public ActionResult<ImageResponse> Update(int id, UpdateImageRequest model)
        {
            if (id != Account.Id && Account.Role != Role.Admin)
                return Unauthorized(new { message = "Unauthorized" });

            var image = _imageService.Update(id, model);
            return Ok(image);
        }

        //1. jako parametr podać list
        //2. interacja po liście foreach
        //3. dodawanie elementów do bazy
        //4. return Liste
        [HttpPost]
        public ActionResult Create(IList<CreateImageRequest> model)
        {
            Image image = new();
            foreach (var item in model)
            {
                item.AccountId = Account.Id;
                _imageService.Create(item);
            }
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            // users can delete their own account and admins can delete any account
            if (id != Account.Id && Account.Role != Role.Admin)
                return Unauthorized(new { message = "Unauthorized" });

            _imageService.Delete(id);
            return Ok(new { message = "Account deleted successfully" });
        }

    }
}
