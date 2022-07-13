using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebAlbum.Models.Folders.Request
{
    public class CreateFolderRequest
    {
        [Required]
        public string FolderName { get; set; }
        public string? FolderDescription { get; set; }
        public List<int>? ImagesId { get; set; }

        [JsonIgnore]
        public int AccountId { get; set; }
        public int? ParentFolderId { get; set; }
        public List<int>? InverseParentFolder { get; set; }
    }
}
