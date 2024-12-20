using NewspapperAPI.Models.ModelDto.AuthDto;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace NewspapperAPI.Repository.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        public AuthService(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }


        public async Task<AuthServiceResponseDto> LoginAsync(LoginDto loginDto)
        {
            var appUser = await _userManager.FindByEmailAsync(loginDto.EmailAdress);
            if (appUser is null)
            {
                return new AuthServiceResponseDto()
                {
                    IsSucceed = false,
                    Message = "User not found."
                };
            }
            //Checking the authenticity of the password
            var checkPassword = await _userManager.CheckPasswordAsync(appUser, loginDto.Password);
            if (!checkPassword)
            {
                return new AuthServiceResponseDto()
                {
                    IsSucceed = false,
                    Message = "Invalid username or password"
                };
            }
            //Getting the roles of the user
            var getUserRole = await _userManager.GetRolesAsync(appUser);

            //Implimenting the claimType
            var authClaim = new List<Claim>
            {
                new Claim(ClaimTypes.Name, appUser.Email),
                new Claim(ClaimTypes.NameIdentifier, appUser.Id),
                new Claim("JWTID", Guid.NewGuid().ToString()),
                new Claim("FirstName", appUser.FirstName),
                new Claim("LastName", appUser.LastName)
            };
            //Looping through the roles in the claim
            foreach (var role in getUserRole)
            {
                authClaim.Add(new Claim(ClaimTypes.Role, role));
            }
            //Generating new Json web token
            var token = GenerateNewJsonWebToken(authClaim);
            return new AuthServiceResponseDto()
            {
                IsSucceed = true,
                Message = token
            };

        }

        public Task<AuthServiceResponseDto> MakeAdminAsync(UpdatePermissionDto updatePermissionDto)
        {
            throw new NotImplementedException();
        }

        public Task<AuthServiceResponseDto> MakeOwnerAsync(UpdatePermissionDto updatePermissionDto)
        {
            throw new NotImplementedException();
        }

        public async Task<AuthServiceResponseDto> RegisterAsync(RegisterDto registerDto)
        {
            var isUserExist = await _userManager.FindByEmailAsync(registerDto.EmailAdress);
            if (isUserExist != null)
                return new AuthServiceResponseDto()
                {
                    IsSucceed = false,
                    Message = "User already exist, pls login."
                };

            var appUser = new ApplicationUser()
            {
                UserName = registerDto.UserName,
                Email = registerDto.EmailAdress,
                SecurityStamp = Guid.NewGuid().ToString()
            };

            //Creating the User along with the password provided
            var createNewUser = await _userManager.CreateAsync(appUser, registerDto.Password);
            if (!createNewUser.Succeeded)
            {
                var errorString = "Registration failed:";
                foreach (var error in createNewUser.Errors)
                {
                    errorString += "#" + error.Description;
                }

                return new AuthServiceResponseDto()
                {
                    IsSucceed = false,
                    Message = errorString
                };
            }
            //Checking if Admin already exist in the Admin roles
            var usersInRole = await _userManager.GetUsersInRoleAsync(StaticUserRole.ADMIN);
            if (!usersInRole.Any())
            {
                await _userManager.AddToRoleAsync(appUser, StaticUserRole.ADMIN);
            }
            else
            {
                await _userManager.AddToRoleAsync(appUser, StaticUserRole.READER);
            }

            return new AuthServiceResponseDto()
            {
                IsSucceed = true,
                Message = "Registration successful."
            };
        }

        public async Task<AuthServiceResponseDto> SeedRolesAsync()
        {
            bool isAdminRoleExist = await _roleManager.RoleExistsAsync(StaticUserRole.ADMIN);
            bool isOwnerRoleExist = await _roleManager.RoleExistsAsync(StaticUserRole.READER);
            if (isAdminRoleExist && isOwnerRoleExist)
            {
                return new AuthServiceResponseDto()
                {
                    IsSucceed = true,
                    Message = "Roles already exist."
                };
            }
            await _roleManager.CreateAsync(new IdentityRole(StaticUserRole.ADMIN));
            await _roleManager.CreateAsync(new IdentityRole(StaticUserRole.READER));
            return new AuthServiceResponseDto()
            {
                IsSucceed = true,
                Message = "Role seeded successfully."
            };
        }

        //Method for Generating New Json Web Token
        public string GenerateNewJsonWebToken(List<Claim> claims)
        {
            var authSecret = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]));
            var tokenObject = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(1),
                claims: claims,
                signingCredentials: new SigningCredentials(authSecret, SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(tokenObject);
        }

    }
}
