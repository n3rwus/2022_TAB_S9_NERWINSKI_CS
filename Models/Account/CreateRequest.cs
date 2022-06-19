using System.ComponentModel.DataAnnotations;
using TABv3.Entities;

namespace TABv3.Models.Account
{
    public class CreateRequest
    {
        
        [Required]
        public string FirstName { get; set; }

        [Required]
        [EnumDataType(typeof(Role))]
        public string Role { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [MinLength(6)]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
