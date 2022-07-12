using System.Text.Json.Serialization;

namespace WebAlbum.Models.Categores.Response
{
    public class CategoryResponse
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }

        [JsonIgnore]
        public int AccountId { get; set; }
    }
}
