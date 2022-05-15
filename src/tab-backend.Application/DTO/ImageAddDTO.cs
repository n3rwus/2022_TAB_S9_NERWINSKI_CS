using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tab_backend.Application.DTO
{
    public class ImageAddDTO
    {
        public string Name { get; set; }
        public byte[] Picture { get; set; }
        public string Description { get; set; }
        public string Size { get; set; }
        public string Format { get; set; }

        public int UserID { get; set; }
        public int FolderID { get; set; }
        public IEnumerable<string> CategoriesName { get; set; }
    }
}
