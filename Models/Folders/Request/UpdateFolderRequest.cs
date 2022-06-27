using System.ComponentModel.DataAnnotations;

namespace WebAlbum.Models.Folders.Request
{
    public class UpdateFolderRequest
    {
        [Required]
        public int Id { get; set; }
        public string? FolderName { get; set; } = null!;
        public string? FolderDescription { get; set; }
        public int? ParentFolderId { get; set; }
    }
}
