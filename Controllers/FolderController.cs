using Microsoft.AspNetCore.Mvc;
using WebAlbum.Models.Folders;
using WebAlbum.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAlbum.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FolderController : ControllerBase
    {

        private readonly IFolderService _folderService;

        public FolderController(IFolderService folderService)
        {
            _folderService = folderService;
        }

        [HttpPost("GetMainFolder")]
        public IActionResult GetMainFolder(GetMainFolderRequest request)
        {
            var response = _folderService.GetMainFolder(request);

            if (response != null) return Ok(response);
            else return NotFound();
        }

        [HttpPost("GetFolder")]
        public IActionResult GetFolder(GetFolderRequest request)
        {
            var response = _folderService.GetFolder(request);

            if (response != null) return Ok(response);
            else return NotFound();
        }

        [HttpPost("AddFolder")]
        public IActionResult AddFolder(AddFolderRequest request)
        {
            var response = _folderService.AddFolder(request);

            if (response != null) return Ok(response);
            else return BadRequest();
        }

        [HttpPost("DeleteFolder")]
        public IActionResult DeleteFolder(DeleteFolderRequest request)
        {
            var response = _folderService.DeleteFolder(request);

            if (response != null) return Ok(response);
            else return NotFound();
        }

        [HttpPost("GetFoldersList")]
        public IActionResult GetFolderList(GetFoldersListRequest request)
        {
            var response = _folderService.GetFolderList(request);

            if (response != null) return Ok(response);
            else return NotFound();
        }
    }
}
