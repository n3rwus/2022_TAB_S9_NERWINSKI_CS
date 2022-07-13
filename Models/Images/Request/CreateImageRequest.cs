using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using WebAlbum.Entities;

namespace WebAlbum.Models.Images.Request
{
    public class CreateImageRequest
    {
        [Required]
        public byte[] Images { get; set; } = null!;
        public string? ImageTitle { get; set; }
        public int? FolderId { get; set; }
        public DateTime DateOfCreate { get; set; }
        public string? Description { get; set; }

        [JsonIgnore]
        public int AccountId { get; set; }
        public List<int>? CategoresId { get; set; }

    }
}
