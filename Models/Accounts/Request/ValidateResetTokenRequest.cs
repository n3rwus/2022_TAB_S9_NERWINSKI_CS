using System.ComponentModel.DataAnnotations;

namespace WebAlbum.Models.Accounts.Request
{
    public class ValidateResetTokenRequest
    {
        [Required]
        public string Token { get; set; }
    }
}
