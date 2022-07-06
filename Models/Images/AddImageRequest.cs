namespace WebAlbum.Models.Images
{
    public class AddImageRequest
    {
        public string UserToken { get; set; }
        public string Title { get; set; }
        public int Id { get; set; }
        public string Description { get; set; }
        public string[] Tags { get; set; }
        public DateTime Date { get; set; }
        public IEnumerable<byte[]> Images { get; set; }
    }
}
