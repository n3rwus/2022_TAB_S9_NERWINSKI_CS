using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tab_backend.Domain.Entities
{
    [Table("Images")]
    public class Image
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public byte[] Picture { get; set; }
        public string Description { get; set; }
        public string Size { get; set; }
        public string Format { get; set; }
        public DateTime DateOfCreate { get; set; }

        public User User { get; set; }
        public IEnumerable<Folder> Folders { get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}
