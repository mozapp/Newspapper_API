using System.ComponentModel.DataAnnotations;

namespace NewspapperAPI.Models.ModelDto.AuthDto
{
    public class UpdatePermissionDto
    {
        [Required(ErrorMessage = "Username required")]
        public string Username { get; set; }
    }
}
