using System.ComponentModel.DataAnnotations;

namespace TABv3.Entities
{
    public class Folder
    {
        [Key]
        public int Id { get; set; }
        public string FolderName { get; set; }
        public string? FolderDescription { get; set; }
        public int MainFolderId { get; set; }
        public MainFolder MainFolder { get; set; }
        public int ParentFolderId { get; set; }
        public Folder ParentFolder { get; set; }
        public ICollection<ImageFolder> ImageFolder { get; set; }
        public ICollection<Folder> Folders { get; set; }
    }
}
