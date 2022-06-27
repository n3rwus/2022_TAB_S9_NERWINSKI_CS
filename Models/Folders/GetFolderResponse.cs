using WebAlbum.Entities;

namespace WebAlbum.Models.Folders
{
    public class GetFolderResponse
    {
        public string FolderName { get; set; }
        public ICollection<Folder> NestedFolders { get; set; }
        public ICollection<GetFolderResponse> Images { get; set; }
    }
}
