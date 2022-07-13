using System.Text.Json.Serialization;

namespace WebAlbum.Models.Folders.Respons
{
    public class FolderResponse
    {
        public int Id { get; set; }
        public string FolderName { get; set; }
        public string FolderDescription { get; set; }
        public int? ParentFolderId { get; set; }
        public List<int>? InverseParentFolder { get; set; }
    }
}
