using System.ComponentModel.DataAnnotations;

namespace WebAlbum.Models.Accounts.Request
{
    public class ForgotPasswordRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
