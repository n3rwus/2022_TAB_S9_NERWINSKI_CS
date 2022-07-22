using WebAlbum.Entities;
using WebAlbum.Models.Images;

namespace WebAlbum.Models.Folders
{
    public class GetFolderResponse
    {
        public string FolderName { get; set; }
        public int ParentFolderId { get; set; }
        public ICollection<Folder> InverseParentFolder { get; set; }
        public ICollection<GetImageResponse> Images { get; set; }
    }
}
