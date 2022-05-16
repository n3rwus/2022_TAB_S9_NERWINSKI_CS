using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tab_backend.Application.DTO;
using tab_backend.Application.Interfaces;

namespace tab_backend.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImageService _imageService;
        private readonly ICategoryService _categoryService;

        public ImageController(IImageService imageService, ICategoryService categoryService)
        {
            _imageService = imageService;
            _categoryService = categoryService;
        }

        [SwaggerOperation(Summary = "Get All images")]
        [HttpGet]
        public IActionResult GetAllImages()
        {
            var images = _imageService.GetAllImage();
 
            return Ok(images);
        }

        [SwaggerOperation(Summary = "Add image")]
        [HttpPost("add")]
        public IActionResult AddImage(ImageAddDTO image)
        {
            var addedImage = _imageService.AddImage(image);

            if(addedImage == null) return BadRequest(new { message = "something went wrong" });

            return Ok(addedImage);
        }

        [SwaggerOperation(Summary = "Delete image")]
        [HttpDelete("delete/{id}")]
        public IActionResult DeleteImage(int id)
        {
            var image = _imageService.GetImageByID(id);

            if (image == null) return NotFound();

             _imageService.DeleteImage(image);

            return Ok();
        }
        

        [SwaggerOperation(Summary = "Get Image By Category")]
        [HttpGet("category/{id}")]
        public IActionResult GetImageByCategory(int id)
        {
            var category = _categoryService.GetCategoryByID(id);

            var images = _imageService.GetImageByCategory(category);

            if (images == null) return BadRequest(new { message = "something went wrong" });

            return Ok(images);
        }

        [SwaggerOperation(Summary = "Get Image By Size")]
        [HttpGet("size/{size}")]
        public IActionResult GetImageBySize(string size)
        {
            var images = _imageService.GetImageBySize(size);

            if (images == null) return NotFound();

            return Ok(images);
        }

        [SwaggerOperation(Summary = "Get Image By Format")]
        [HttpGet("format/{format}")]
        public IActionResult GetImageByFormat(string format)
        {
            var images = _imageService.GetImageByFormat(format);

            if (images == null) return NotFound();

            return Ok(images);
        }

        [SwaggerOperation(Summary = "Get Image By Date")]
        [HttpGet("date/{year}/{month}/{day}")]
        public IActionResult GetImageByDate(int year, int month, int day)
        {
            var date = new DateTime(year, month, day);

            var images = _imageService.GetImageByDate(date);

            if (images == null) return NotFound();

            return Ok(images);
        }
    }
}
