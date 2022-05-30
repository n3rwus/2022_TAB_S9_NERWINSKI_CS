using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tab_backend.Domain.Entities
{
    public class ImageCategory
    {
        public int ImageID { get; set; }

        public Image Image { get; set; }

        public int CategoryID { get; set; }

        public Category Category { get; set; }
    }
}
