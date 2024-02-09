using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using baigiamasis2.DTO;
using baigiamasis2.Models;
using baigiamasis2.Services.Mappers;

namespace baigiamasis2.Services.Authorization
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly IPasswordHasher<User> _passwordHasher;
        private readonly IUserMapper _mapper;

        public AuthService(UserManager<User> userManager, SignInManager<User> signInManager, IConfiguration configuration, IPasswordHasher<User> passwordHasher, IUserMapper userMapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _configuration = configuration;
            _passwordHasher = passwordHasher;
            _mapper = userMapper;
        }

        public async Task<string> LoginAsync(string UserName, string Password)
        {
            var user = await _userManager.FindByNameAsync(UserName);

            if (user == null || !await _userManager.CheckPasswordAsync(user, Password))
            {
                throw new InvalidOperationException("Invalid username or password.");
            }

            var roles = await _userManager.GetRolesAsync(user);
            var token = GenerateJwtToken(user, roles);

            return token;
        }

        public async Task<string> SignUpAsync(LoginInfoDto signUpDto)
        {
            _mapper.MapToUserEntity(signUpDto);

            // Хеширование пароля с использованием PasswordHasher
            var passwordHash = _passwordHasher.HashPassword(user, Encoding.UTF8.GetString(signUpDto.Password));
            user.LoginInfo.Password = passwordHash;

            var result = await _userManager.CreateAsync(user);

            if (!result.Succeeded)
            {
                throw new InvalidOperationException(result.Errors.First().Description);
            }

            await _userManager.AddToRoleAsync(user, signUpDto.Role);

            var roles = await _userManager.GetRolesAsync(user);
            var token = GenerateJwtToken(user, roles);

            return token;
        }

        private string GenerateJwtToken(User user, IList<string> roles)
        {
            var key = Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]);
            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];
            var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.UserName),
        };

            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(Convert.ToInt32(_configuration["Jwt:ExpireHours"])),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = issuer,
                Audience = audience,
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

    }
}
