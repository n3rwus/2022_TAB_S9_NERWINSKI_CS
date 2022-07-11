using System.ComponentModel.DataAnnotations;

namespace WebAlbum.Models.Categores.Request
{
    public class CreateCategoryRequest
    {
        [Required]
        public string CategoryName { get; set; }
    }
}
