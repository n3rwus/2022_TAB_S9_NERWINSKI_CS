using System.ComponentModel.DataAnnotations;

namespace WebAlbum.Models.Categores.Request
{
    public class DeleteCategoryRequest
    {
        [Required]
        public int Id { get; set; }
    }
}
