using baigiamasis2.Data;
using baigiamasis2.DTO;
using baigiamasis2.Models;
using baigiamasis2.Services.Mappers;

namespace baigiamasis2.Services.UserServices
{
    public class UserService : IUserService
    {
        private readonly IDbRepository _dbRepository;
        private readonly IUserMapper _userMapper;

        public UserService(IDbRepository dbRepository, IUserMapper userMapper)
        {
            _dbRepository = dbRepository;
            _userMapper = userMapper;
        }

        public long CreateUser(CreateUserDto createUserDto)
        {
            User user = _userMapper.MapToUserEntity(createUserDto);
            return _dbRepository.Create(user);
        }

        public void UpdateUser(UpdateUserDto updateUserDto)
        {
            User user = _userMapper.MapToUserEntity(updateUserDto);
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
                throw new InvalidOperationException("Cannot create user address with an existing ID.");
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

        public void CreateImage(ImageDto imageDto)
        {
            Image image = _userMapper.MapToImageEntity(imageDto);
            if (image.Id == 0)
            {
                _dbRepository.CreatImage(image);
            }
            else
            {
                throw new InvalidOperationException("Cannot create image with an existing ID.");
            }
        }

        public void UpdateImage(ImageUpdateDto imageUpdateDto)
        {
            Image image = _userMapper.MapToImageEntity(imageUpdateDto);
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
