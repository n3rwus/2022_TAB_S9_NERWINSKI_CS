using System.ComponentModel.DataAnnotations;

namespace TABv3.Entities
{
    public class Folder
    {
        public Folder()
        {
            ChildrenFolders = new HashSet<Folder>();
        }

        [Key]
        public int Id { get; set; }
        public string FolderName { get; set; }
        public string? FolderDescription { get; set; }

        //relacje

        public int AccountId { get; set; }
        public Account Account { get; set; }
        public ICollection<Image> Images { get; set; }

        public int? ParentFolderId { get; set; }
        public virtual Folder ParentFolder { get; set; }
        public virtual ICollection<Folder> ChildrenFolders { get; set; }
    }
}
