namespace WebAlbum.Models.Folders
{
    public class DeleteFolderRequest
    {
        public string UserToken { get; set; }
        public int FolderId { get; set; }

    }
}
