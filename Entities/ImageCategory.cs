namespace TABv3.Entities
{
    public class ImageCategory
    {
        public int ImageId { get; set; }
        public Image Image { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
