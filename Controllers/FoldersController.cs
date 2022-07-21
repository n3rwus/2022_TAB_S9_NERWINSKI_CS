using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAlbum.Authorization;
using WebAlbum.Models.Folders.Request;
using WebAlbum.Models.Folders.Respons;
using WebAlbum.Services;

namespace WebAlbum.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class FoldersController : BaseController
    {
        private readonly IFolderService _folderService;
        private int _accountId;

        public FoldersController(IFolderService folderService, int accountId)
        {
            _folderService = folderService;
            _accountId = accountId;
        }

        [HttpGet]
        public ActionResult<IEnumerable<FolderResponse>> GetAll()
        {
            var folders = _folderService.GetAll();
            return Ok(folders);
        }

        [HttpGet("{id:int}")]
        public ActionResult<FolderResponse> GetById(int id)
        {
            var folder = _folderService.GetById(id);
            return Ok(folder);
        }

        [HttpPut("{id:int}")]
        public ActionResult Update(int id, UpdateFolderRequest model)
        {
            _folderService.Update(id, model);
            return NoContent();
        }

        [HttpPost]
        public ActionResult Create(CreateFolderRequest model)
        {
            model.AccountId = _accountId;
            _folderService.Create(model);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            _folderService.Delete(id);
            return Ok(new { message = "Image deleted successfully" });
        }

    }
}
