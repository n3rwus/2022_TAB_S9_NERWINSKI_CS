namespace TABv3.Entities
{
    public class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public int AccountId { get; set; }
        public  Account Account { get; set; }
        public ICollection<ImageCategory> ImageCategories { get; set; }
    }
}
