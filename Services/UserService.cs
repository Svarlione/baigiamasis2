using baigiamasis2.Data;
using baigiamasis2.Models;

namespace baigiamasis2.Services
{
    public class UserService : IUserService
    {
        private readonly IDbRepository _dbRepository;

        public UserService(IDbRepository dbRepository)
        {
            _dbRepository = dbRepository;
        }

        public long CreateUser(User user)
        {

            return _dbRepository.Create(user);
        }

        public void UpdateUser(User user)
        {

            _dbRepository.UpdateUser(user);
        }

        public void DeleteUser(long userId)
        {

            _dbRepository.DeleteUser(userId);
        }

        public User GetUserByUserId(long userId)
        {

            return _dbRepository.GetUserByUserId(userId);
        }

        public void CreateUserAddress(UserAdress userAddress)
        {
            if (userAddress.Id == 0)
            {
                _dbRepository.CreateAdress(userAddress);
            }
            else
            {

                throw new InvalidOperationException("Cannot create user address with existing ID.");
            }
        }

        public void UpdateUserAddress(UserAdress userAddress)
        {
            if (userAddress.Id != 0)
            {
                _dbRepository.UpdateAdress(userAddress);
            }
            else
            {

                throw new InvalidOperationException("Cannot update user address with zero ID.");
            }
        }

        public void CreateImage(Image image)
        {
            if (image.Id == 0)
            {
                _dbRepository.CreatImage(image);
            }
            else
            {

                throw new InvalidOperationException("Cannot create image with existing ID.");
            }
        }

        public void UpdateImage(Image image)
        {
            if (image.Id != 0)
            {
                _dbRepository.UpdateImage(image);
            }
            else
            {

                throw new InvalidOperationException("Cannot update image with zero ID.");
            }
        }
    }
}
