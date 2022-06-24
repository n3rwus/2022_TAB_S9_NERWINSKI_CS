using System.ComponentModel.DataAnnotations;

namespace WebAlbum.Models.Accounts
{
    public class VerifyEmailRequest
    {
        [Required]
        public string Token { get; set; }
    }
}
