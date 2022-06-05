using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tab_backend.Domain.Entities
{
    [Table("Images")]
    public class Image
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        [Required]
        public byte[] Picture { get; set; }

        public string Description { get; set; }

        public string Size { get; set; }
        public string Format { get; set; }

        [Required]
        public DateTime DateOfCreate { get; set; }

        public int UserID { get; set; }

        [Required]
        public User User { get; set; }

        [Required]
        public IEnumerable<ImageFolder> ImageFolder { get; set; }

        public IEnumerable<ImageCategory> ImageCategory { get; set; }
    }
}
