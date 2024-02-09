using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using baigiamasis2.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace baigiamasis2.Services.Authorization
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly IPasswordHasher<User> _passwordHasher;

        public AuthService(IConfiguration configuration, IPasswordHasher<User> passwordHasher)
        {
            _configuration = configuration;
            _passwordHasher = passwordHasher;
        }

        public async Task<string> LoginAsync(string userName, string password)
        {
            // Реализуйте логику поиска пользователя и проверки пароля
            var user = await FindUserByNameAsync(userName);

            if (user == null || !VerifyPassword(user.LoginInfo, password))
            {
                throw new InvalidOperationException("Invalid username or password.");
            }

            var token = GenerateJwtToken(user.LoginInfo);

            return token;
        }

        public async Task<string> SignUpAsync(string username, string role, string password)
        {
            var loginInfo = new LoginInfo
            {
                UserName = username,
                Password = HashPassword(password),
                Role = role
            };

            // Реализуйте логику добавления пользователя в роль

            var token = GenerateJwtToken(loginInfo);

            return token;
        }

        private byte[] HashPassword(string password)
        {
            return Encoding.UTF8.GetBytes(_passwordHasher.HashPassword(null, password));
        }

        private bool VerifyPassword(LoginInfo loginInfo, string password)
        {
            var result = _passwordHasher.VerifyHashedPassword(null, Convert.ToBase64String(loginInfo.Password), password);
            return result == PasswordVerificationResult.Success;
        }



        private string GenerateJwtToken(LoginInfo loginInfo)
        {
            var key = Encoding.UTF8.GetBytes(_configuration["Jwt:SecretKey"]);
            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, loginInfo.UserId.ToString()),
                new Claim(ClaimTypes.Name, loginInfo.UserName, ClaimValueTypes.String),
                new Claim(ClaimTypes.Role, loginInfo.Role),
            };

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


        // Реализуйте логику поиска пользователя
        private Task<User> FindUserByNameAsync(string userName)
        {
            return Task.FromResult(new User { LoginInfo = new LoginInfo { UserName = userName } });

        }
    }
}
