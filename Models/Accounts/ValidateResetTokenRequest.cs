using System.ComponentModel.DataAnnotations;

namespace WebAlbum.Models.Accounts
{
    public class ValidateResetTokenRequest
    {
        [Required]
        public string Token { get; set; }
    }
}
