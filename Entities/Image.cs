namespace TABv3.Entities
{
    public class Image
    {
        public int Id { get; set; }
        public string ImageTitle { get; set; }
        public byte[] ImageData { get; set; }
        public string? ImageDescription  { get; set; }
        public int? ImageSize { get; set; }
        public string? ImageFormat { get; set; }
        public DateTime ImageDateOfCreate { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }
        public ICollection<ImageFolder> ImageFolders { get; set; }
        public ICollection<ImageCategory> ImageCategories { get; set; }
    }
}
