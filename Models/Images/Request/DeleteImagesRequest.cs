using System.ComponentModel.DataAnnotations;

namespace WebAlbum.Models.Images.Request
{
    /*    DeleteImage
    -----------------
    Request:

    UserToken: string
    idZdjęcia: int/string

    Response:

    Status*/
    public class DeleteImagesRequest
    {
        [Required]
        public string Token { get; set; }
        [Required]
        public int ImageId { get; set; }
    }
}
