namespace TABv3.Entities
{
    public class Folder
    {
        public int Id { get; set; }
        public string FolderName { get; set; }
        public string? FolderDescription { get; set; }
        public int? ParentFolderId { get; set; }
        public virtual Folder ParentFolder { get; set; }
        public virtual ICollection<Folder> ChildrenFolder { get; set; }
        public int AccountId { get; set; }
        public Account Account { get; set; }

    }
}
