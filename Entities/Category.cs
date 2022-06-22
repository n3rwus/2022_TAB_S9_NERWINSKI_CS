﻿namespace TABv3.Entities
{
    public class Category
    {
        public Category()
        {
            this.Images = new HashSet<Image>();
        }

        public int Id { get; set; }
        public string CategoryName { get; set; }
        public int AccountId { get; set; }
        public  Account Account { get; set; }
        public ICollection<Image> Images { get; set; }
    }
}