using System.ComponentModel.DataAnnotations;

namespace WebAlbum.Models.Images.Request
{
    public class UpdateImageRequest
    {
        [Required]
        public string Token { get; set; }
        [Required]
        public int Id { get; set; }
        public int? FolderId { get; set; }
        public string? ImageTitle { get; set; }
        public string? ImageDescription { get; set; }
        public List<string>? Categores { get; set; }
        public DateTime? ImageDateOfCreate { get; set; }

    }
}
