using System.ComponentModel.DataAnnotations;

namespace DigitizingProjectCore.Dto
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Enter_Your_Username_Or_Email")]
        public string Username { get; set; } = string.Empty;
        [Required(ErrorMessage = "Enter_Your_Password")]
        public string Password { get; set; } = string.Empty;
        public string? ReturnUrl { get; set; }
    }
}
