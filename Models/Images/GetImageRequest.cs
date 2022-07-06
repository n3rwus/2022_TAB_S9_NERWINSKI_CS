namespace WebAlbum.Models.Images
{
    public class GetImageRequest
    {
        public string UserToken { get; set; }
        public int Id { get; set; }
        public int? FolderId { get; set; }
    }
}
