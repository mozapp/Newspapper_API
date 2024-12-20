using Microsoft.AspNetCore.Mvc;
using NewspapperAPI.Models.ModelDto.AuthDto;

namespace NewspapperAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            var registerResult = await _authService.RegisterAsync(registerDto);
            if (registerResult.IsSucceed)
                return Ok(registerResult);
            return BadRequest(registerResult);
        }


        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var loginResult = await _authService.LoginAsync(loginDto);
            if (loginResult.IsSucceed)
                return Ok(loginResult);
            return Unauthorized(loginResult);
        }

        [HttpPost]
        [Route("seedroles")]
        public async Task<IActionResult> SeedRoles()
        {
            var seedrole = await _authService.SeedRolesAsync();
            return Ok(seedrole);
        }
    }
}
