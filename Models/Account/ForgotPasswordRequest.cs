using System.ComponentModel.DataAnnotations;

namespace TABv3.Models.Account
{
    public class ForgotPasswordRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
