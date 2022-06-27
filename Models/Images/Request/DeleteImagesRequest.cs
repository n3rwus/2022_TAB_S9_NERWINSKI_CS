using System.ComponentModel.DataAnnotations;

namespace WebAlbum.Models.Images.Request
{
    public class DeleteImagesRequest
    {
        [Required]
        public int ImageId { get; set; }
    }
}
