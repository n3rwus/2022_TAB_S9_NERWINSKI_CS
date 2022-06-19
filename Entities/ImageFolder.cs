namespace TABv3.Entities
{
    public class ImageFolder
    {
        public int FolderId { get; set; }
        public Folder Folder { get; set; }
        public int ImageId { get; set; }
        public Image Image { get; set; }
    }
}
