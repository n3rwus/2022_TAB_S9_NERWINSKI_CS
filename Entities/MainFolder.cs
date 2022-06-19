using System.ComponentModel.DataAnnotations.Schema;

namespace TABv3.Entities
{
    public class MainFolder
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public  Account Account { get; set; }
        public ICollection<Folder> Folders { get; set; }
    }
}
