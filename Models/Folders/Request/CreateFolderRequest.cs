using System.ComponentModel.DataAnnotations;

namespace WebAlbum.Models.Folders.Request
{
    public class CreateFolderRequest
    {
        [Required]
        public string FolderName { get; set; }
        public string? FolderDescription { get; set; }
    }
}
