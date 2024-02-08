using System.ComponentModel.DataAnnotations;

namespace baigiamasis2.DTO
{
    public class CreateUserDto
    {
        [Required(ErrorMessage = "Vardas yra privalomas")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Pavardė yra privaloma")]
        public string LaststName { get; set; }

        [Required(ErrorMessage = "Asmens kodas yra privalomas")]
        public string PersonalIndefication { get; set; }

        [Required(ErrorMessage = "El. paštas yra privalomas")]
        [EmailAddress(ErrorMessage = "Netinkamas el. pašto formatas")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Prisijungimo informacija yra privaloma")]
        public LoginInfoDto LoginInfo { get; set; }

        [Required(ErrorMessage = "Adreso informacija yra privaloma")]
        public AdressDto Address { get; set; }

        [Required(ErrorMessage = "Nuotrauka yra privaloma")]
        public ImageDto Image { get; set; }

        [Required(ErrorMessage = "Telefono numeris yra privalomas")]
        [RegularExpression(@"^\d{9}$", ErrorMessage = "Netinkamas telefono numerio formatas")]
        public string PhoneNumber { get; set; }
    }
}
