using System.ComponentModel.DataAnnotations;

namespace WebAlbum.Models.Folders.Request
{
    public class AddFolderRequest
    {
        [Required]
        public string FolderName { get; set; }
        public string? FolderDescription { get; set; }
    }
}
