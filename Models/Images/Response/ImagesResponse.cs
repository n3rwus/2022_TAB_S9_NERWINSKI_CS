namespace WebAlbum.Models.Images.Response
{
    public class ImagesResponse
    {
        public int Id { get; set; }
        public byte[] Image { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? FolderId { get; set; }
        public List<string>? Categores { get; set; }
        public DateTime? DateOfCreate { get; set; }
    }
}
