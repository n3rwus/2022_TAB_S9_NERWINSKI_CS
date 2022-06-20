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

        //relacje

        public int AccountId { get; set; }
        public Account Account { get; set; }
        public int FolderId { get; set; }
        public Folder Folder { get; set; }
        public ICollection<Category> Categories { get; set; }
    }
}
