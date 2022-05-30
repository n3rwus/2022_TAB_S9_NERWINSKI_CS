using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tab_backend.Domain.Entities
{
    [Table("MainFolder")]
    public class MainFolder
    {
        [Key]
        public int ID { get; set; }

        public int UserID { get; set; }

        [Required]
        public User User { get; set; }

        public IEnumerable<Folder> Folders { get; set; }
    }
}
