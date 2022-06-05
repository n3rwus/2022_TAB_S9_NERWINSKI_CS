using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tab_backend.Domain.Entities
{
    [Table("Users")]
    public class User
    {
        public User()
        {

        }

        public User(int id, string firstName, string email, string password, DateTime registerDate)
        {
            ID = id;
            FirstName = firstName;
            Email = email;
            Password = password;
            RegisterDate = registerDate;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(18, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [RegularExpression(@"^((?=.*[a-z])(?=.*[A-Z])(?=.*\d)).+$")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        public DateTime RegisterDate { get; set; }

        public IEnumerable<Image> Images { get; set; }

        public MainFolder Folder { get; set; }

        public IEnumerable<Category> Categories { get; set; }
        
    }
}
