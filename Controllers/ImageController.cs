using Microsoft.AspNetCore.Mvc;
using WebAlbum.Models.Images;
using WebAlbum.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAlbum.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImageService _imageService;

        public ImageController(IImageService imageService)
        {
            _imageService = imageService;
        }

        [HttpPost("AddImages")]
        public IActionResult AddImages(AddImageRequest request)//TODO
        {
            var response = _imageService.AddImages(request);

            if (response != null) return Ok(response);
            else return NotFound();
        }

        [HttpPost("GetImage")]
        public IActionResult GetImage(GetImageRequest request)
        {
           var response = _imageService.GetImage(request);

            if (response != null) return Ok(response);
            else return NotFound();
        }

        [HttpPost("EditImage")]
        public IActionResult EditImage(EditImageRequest request) //TODO
        {
            var response = _imageService.EditImage(request);

            if (response != null) return Ok(response);
            else return NotFound();
        }

        [HttpPost("DeleteImage")]
        public IActionResult DeleteImage(DeleteImageRequest request)
        {
            var response = _imageService.DeleteImage(request);

            if (response != null) return Ok(response);
            else return NotFound();
        }
    }
}
