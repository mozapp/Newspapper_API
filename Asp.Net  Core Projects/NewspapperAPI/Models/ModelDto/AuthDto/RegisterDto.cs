using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace NewspapperAPI.Models.ModelDto.AuthDto
{
    public class RegisterDto
    {
        [Required(ErrorMessage = "Please enter a Username")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Please enter correct EmailAddress")]
        [EmailAddress]
        public string EmailAdress { get; set; }

        [Required(ErrorMessage = "Please enter correct Password")]
        [PasswordPropertyText]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
