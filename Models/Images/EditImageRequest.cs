namespace WebAlbum.Models.Images
{
    public class EditImageRequest
    {
        public string UserToken { get; set; }
        public int ImageId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? FolderId { get; set; }
        public string[] Tags { get; set; }
        public DateTime Date { get; set; }
    }
}
