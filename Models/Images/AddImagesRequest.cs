using System.ComponentModel.DataAnnotations;

namespace WebAlbum.Models.Images
{
    /*    AddImages
    --------------------
    Request:

    UserToken: string,
    Title: string,
    folderId: Id(int?), 
    Description: string,
    Tags: string[],
    Date: date,
    Images: array[bytearray[]]

    Response:

    Status(np. 200 jeśli uda się dodać)*/
    public class AddImagesRequest
    {
        [Required]
        public string Token { get; set; }
        public int? FolderId { get; set; }
        public DateTime? Date { get; set; }
        public string? Description { get; set; }
        public List<string>? Categores { get; set; }
        [Required]
        public List<byte[]> Images { get; set;}

    }
}
