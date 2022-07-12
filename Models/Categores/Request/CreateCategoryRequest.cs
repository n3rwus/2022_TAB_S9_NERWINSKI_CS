using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebAlbum.Models.Categores.Request
{
    public class CreateCategoryRequest
    {
        [Required]
        public string CategoryName { get; set; }

        [JsonIgnore]
        public int AccountId { get; set; }
    }
}
