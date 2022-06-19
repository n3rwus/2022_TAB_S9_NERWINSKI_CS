using System.ComponentModel.DataAnnotations;
namespace TABv3.Models.Account
{
    public class VerifyEmailRequest
    {
        [Required]
        public string Token { get; set; }
    }
}
