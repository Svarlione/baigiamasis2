using baigiamasis2.Models;

namespace baigiamasis2.Services
{
    public interface IUserService
    {
        void CreateImage(Image image);
        long CreateUser(User user);
        void CreateUserAddress(UserAdress userAddress);
        void DeleteUser(long userId);
        User GetUserByUserId(long userId);
        void UpdateImage(Image image);
        void UpdateUser(User user);
        void UpdateUserAddress(UserAdress userAddress);
    }
}