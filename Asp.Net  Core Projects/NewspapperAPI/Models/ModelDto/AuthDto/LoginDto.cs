using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NewspapperAPI.Models.ModelDto.AuthDto
{
    public class LoginDto
    {
        [Required(ErrorMessage = "Please enter correct EmailAddress")]
        [EmailAddress]
        public string EmailAdress { get; set; }

        [Required(ErrorMessage = "Please enter correct Password")]
        [PasswordPropertyText]
        public string Password { get; set; }
    }
}
