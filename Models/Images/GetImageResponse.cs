namespace WebAlbum.Models.Images
{
    public class GetImageResponse
    {
        byte[] Image;
        public string Title { get; set; }
        public string Description { get; set; }
        public int FolderId { get; set; }
        public string[] Tags { get; set; }
        public DateTime Date { get; set; }
    }
}
