using System.ComponentModel.DataAnnotations;

namespace WebAlbum.Models.Accounts.Request
{
    public class VerifyEmailRequest
    {
        [Required]
        public string Token { get; set; }
    }
}
