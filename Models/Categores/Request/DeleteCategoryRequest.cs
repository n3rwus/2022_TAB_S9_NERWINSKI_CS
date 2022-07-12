using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebAlbum.Models.Categores.Request
{
    public class DeleteCategoryRequest
    {
        [Required]
        public int Id { get; set; }
        [JsonIgnore]
        public int AccountId { get; set; }
    }
}
