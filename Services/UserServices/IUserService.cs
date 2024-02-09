using baigiamasis2.DTO;
using baigiamasis2.Models;

namespace baigiamasis2.Services.UserServices
{
    public interface IUserService
    {
        void CreateImage(ImageDto imageDto);
        long CreateUser(CreateUserDto createUserDto);
        void CreateUserAddress(UserAdress userAddress);
        void DeleteUser(long userId);
        User GetUserByUserId(long userId);
        void UpdateImage(ImageUpdateDto imageUpdateDto);
        void UpdateUser(UpdateUserDto updateUserDto);
        void UpdateUserAddress(UserAdress userAddress);
    }
}