using System.ComponentModel.DataAnnotations;
using WebAlbum.Entities;

namespace WebAlbum.Models.Images.Request
{
    public class CreateImageRequest
    {
        [Required]
        public List<byte[]> Images { get; set; }
        public string? ImageTitle { get; set; }
        public int? FolderId { get; set; }
        public DateTime? Date { get; set; }
        public string? Description { get; set; }
        public List<Category>? Categores { get; set; }

    }
}
