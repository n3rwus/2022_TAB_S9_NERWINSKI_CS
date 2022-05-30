using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tab_backend.Domain.Entities
{
    public class ImageFolder
    {
        public int FolderID { get; set; }

        public Folder Folder { get; set; }

        public int ImageID { get; set; }

        public Image Image { get; set; }
    }
}
