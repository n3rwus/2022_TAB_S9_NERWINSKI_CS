using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TABv3.Entities
{
    public class Folder
    {
        public int Id { get; set; }
        public string FolderName { get; set; }
        public string? FolderDescription { get; set; }

        //relacje

        public virtual int AccountId { get; set; }
        public virtual Account Account { get; set; }
        public virtual ICollection<Image> Images { get; set; }

        //self-reference
        public int? ParentFolderId { get; set; }
        public Folder ParentFolder { get; set; }
        public ICollection<Folder> ChildFolders { get; set; }

        
    }
}
