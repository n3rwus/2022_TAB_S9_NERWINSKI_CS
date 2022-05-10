using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tab_backend.Application.DTO
{
    public class FolderDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public UserDTO User { get; set; }
        public FolderDTO ParentFolder { get; set; }
        public IEnumerable<ImageDTO> Images { get; set; }
    }
}
