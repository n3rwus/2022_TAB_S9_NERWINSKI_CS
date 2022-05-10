using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tab_backend.Application.DTO
{
    public class ImageDTO
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public byte[] Picture { get; set; }
        public string Description { get; set; }
        public string Size { get; set; }
        public string Format { get; set; }
        public DateTime DateOfCreate { get; set; }

        public UserDTO User { get; set; }
        public IEnumerable<FolderDTO> Folders { get; set; }
        public IEnumerable<CategoryDTO> Categories { get; set; }
    }
}
