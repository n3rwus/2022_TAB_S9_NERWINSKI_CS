using System.ComponentModel.DataAnnotations;

namespace WebAlbum.Models.Images.Request
{
    public class AddImagesRequest
    {
        [Required]
        public List<byte[]> Images { get; set; }
        public string? ImageTitle { get; set; }
        public int? FolderId { get; set; }
        public DateTime? Date { get; set; }
        public string? Description { get; set; }
        public List<string>? Categores { get; set; }

    }
}
