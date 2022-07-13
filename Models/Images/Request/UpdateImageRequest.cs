using System.ComponentModel.DataAnnotations;

namespace WebAlbum.Models.Images.Request
{
    public class UpdateImageRequest
    {
        [Required]
        public int Id { get; set; }
        public int? FolderId { get; set; }
        public string? ImageTitle { get; set; }
        public string? ImageDescription { get; set; }
        public List<int>? CategoresId { get; set; }
        public DateTime? ImageDateOfCreate { get; set; }

    }
}
