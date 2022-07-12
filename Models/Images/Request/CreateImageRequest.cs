using System.ComponentModel.DataAnnotations;
using WebAlbum.Entities;

namespace WebAlbum.Models.Images.Request
{
    public class CreateImageRequest
    {
        [Required]
        public byte[] Images { get; set; }
        public string? ImageTitle { get; set; }
        public int? FolderId { get; set; }
        public DateTime? Date { get; set; }
        public string? Description { get; set; }

        [Required]
        public int AccountId { get; set; }
        public List<int>? CategoresId { get; set; }

    }
}
