using System.ComponentModel.DataAnnotations;

namespace WebAlbum.Models.Categores.Request
{
    public class AddCategoryRequest
    {
        [Required]
        public string CategoryName { get; set; }
    }
}
