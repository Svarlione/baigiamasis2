using baigiamasis2.DTO;

namespace baigiamasis2.Services.Authorization
{
    public interface IAuthService
    {
        Task<string> LoginAsync(string UserName, string Password);
        Task<string> SignUpAsync(LoginInfoDto signUpDto);
    }
}