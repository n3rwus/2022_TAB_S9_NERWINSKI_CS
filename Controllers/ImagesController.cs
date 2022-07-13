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
        private int _accountId;
        public ImagesController(IImageService imageService)
        {
            _imageService = imageService;
            _accountId = Account.Id;
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
            var image = _imageService.GetById(id);
            return Ok(image);
        }

        [HttpPut("{id:int}")]
        public ActionResult Update(int id, UpdateImageRequest model)
        {
            var image = _imageService.Update(id, model);
            return NoContent();
        }

        //1. jako parametr podać list
        //2. interacja po liście foreach
        //3. dodawanie elementów do bazy
        //4. return Liste

        // Na froncie uzytkownik wybiera kategorie po nazwie
        // ale na backend jest wysylane tylko jego Id
        // przez co tworzymy liste Id kategorii
        // to samo z folderami
        [HttpPost]
        public ActionResult Create(IList<CreateImageRequest> model)
        {
            foreach (var item in model)
            {
                item.AccountId = _accountId;
                item.DateOfCreate = DateTime.Now;
                _imageService.Create(item);
            }
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
           /* if (_imageService.isAuthForImage(Account.Id, id))
            {
                _imageService.Delete(id);
                return Ok(new { message = "Image deleted successfully" });
            }
            return BadRequest();*/

            _imageService.Delete(id);
            return Ok(new { message = "Image deleted successfully" });
        }

    }
}
