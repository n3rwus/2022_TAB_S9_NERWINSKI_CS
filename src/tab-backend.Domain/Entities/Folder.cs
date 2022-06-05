using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tab_backend.Domain.Entities
{
    [Table("Folders")]
    public class Folder
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public int MainFolderID { get; set; }

        public MainFolder MainFolder { get; set; }

        public int ParentFolderID { get; set; }

        public Folder ParentFolder { get; set; }

        public IEnumerable<ImageFolder> ImageFolder { get; set; }

        public IEnumerable<Folder> Folders { get; set; }
    }
}
