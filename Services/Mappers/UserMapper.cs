using baigiamasis2.DTO;
using baigiamasis2.Models;

namespace baigiamasis2.Services.Mappers
{
    public class UserMapper : IUserMapper
    {
        public User MapToUserEntity(CreateUserDto createUserDto)
        {
            return new User()
            {
                FirstName = createUserDto.FirstName,
                LaststName = createUserDto.LaststName,
                PersonalIndefication = createUserDto.PersonalIndefication,
                Email = createUserDto.Email,
                PhoneNumber = createUserDto.PhoneNumber,
                Adress = MapToUserAdressEntity(createUserDto.Address),
                LoginInfo = new LoginInfo()
                {
                    UserName = "",
                    Password = new byte[] { },
                    PasswordSalt = new byte[] { },
                    Role = "user"
                },
                Image = new Image()
                {
                    Name = "",
                    Description = "",
                    ImageBytes = new byte[] { }
                }
            };
        }

        public User MapToUserEntity(UpdateUserDto updateUserDto)
        {
            if (updateUserDto == null)
            {
                return null;
            }

            return new User()
            {
                Email = updateUserDto.Email,
                PhoneNumber = updateUserDto.PhoneNumber,
                LoginInfo = new LoginInfo()
                {
                    Password = updateUserDto.Password

                },
                Adress = MapToUserAdressEntity(updateUserDto.Address),
                Image = MapToImageEntity(updateUserDto.Image)
            };
        }

        public UserAdress MapToUserAdressEntity(AdressDto addressDto)
        {
            if (addressDto == null)
            {
                return null;
            }

            return new UserAdress()
            {
                Town = addressDto.Town,
                Road = addressDto.Road,
                HomeNumer = addressDto.HomeNumer,
                FlatNumber = addressDto.FlatNumber,
                Type = addressDto.Type
            };
        }

        public Image MapToImageEntity(ImageDto imageDto)
        {
            if (imageDto == null)
            {
                return null;
            }

            return new Image()
            {
                Name = imageDto.Name,
                Description = imageDto.Description,
                ImageBytes = imageDto.ImageBytes
            };
        }

        public Image MapToImageEntity(ImageUpdateDto imageUpdateDto)
        {
            if (imageUpdateDto == null)
            {
                return null;
            }

            return new Image()
            {
                Name = imageUpdateDto.Name,
                Description = imageUpdateDto.Description,
                ImageBytes = imageUpdateDto.ImageBytes
            };
        }
    }
}
