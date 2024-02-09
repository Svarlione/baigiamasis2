using baigiamasis2.DTO;
using baigiamasis2.Models;

namespace baigiamasis2.Services.Mappers
{
    public interface IUserMapper
    {
        Image MapToImageEntity(ImageDto imageDto);
        Image MapToImageEntity(ImageUpdateDto imageUpdateDto);
        UserAdress MapToUserAdressEntity(AdressDto addressDto);
        User MapToUserEntity(CreateUserDto createUserDto);
        User MapToUserEntity(UpdateUserDto updateUserDto);
    }
}