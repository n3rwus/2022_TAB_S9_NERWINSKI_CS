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
    [Route("[controller]")]
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

        [HttpPost]
        public ActionResult<ImageResponse> Create(CreateImageRequest model)
        {
            var image = _imageService.Create(model);
            return Ok(image);
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
