using WebAlbum.Entities;
using WebAlbum.Models.Images;

namespace WebAlbum.Models.Folders
{
    public class GetFolderResponse
    {
        public string FolderName { get; set; }
        public ICollection<Folder> NestedFolders { get; set; }
        public ICollection<GetImageResponse> Images { get; set; }
    }
}
