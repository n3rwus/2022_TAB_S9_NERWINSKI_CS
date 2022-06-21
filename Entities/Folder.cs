using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TABv3.Entities
{
    public class Folder
    {

        [Key]
        public int Id { get; set; }
        public string FolderName { get; set; }
        public string? FolderDescription { get; set; }

        //relacje

        public virtual int AccountId { get; set; }
        public virtual Account Account { get; set; }
        public virtual ICollection<Image> Images { get; set; }

        [InverseProperty("IdNext")]
        public virtual Folder Next { get; set; }
        [InverseProperty("IdPrev")]
        public virtual Folder Prev { get; set; }

        [ForeignKey("Id")]
        public virtual int IdNext { get; set; }
        [ForeignKey("Id")]
        public virtual int IdPrev { get; set; }
    }
}
