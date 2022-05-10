using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tab_backend.Domain.Entities
{
    public class Folder
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public User User { get; set; }
        public Folder ParentFolder { get; set; }
        public IEnumerable<Image> Images { get; set; }
    }
}
