using System.ComponentModel.DataAnnotations;

namespace TABv3.Models.Account
{
    public class ValidateResetTokenRequest
    {
        [Required]
        public string Token { get; set; }
    }
}
