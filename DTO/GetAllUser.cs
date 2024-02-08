namespace baigiamasis2.DTO
{
    public class GetAllUser
    {
        public string FirstName { get; set; }
        public string LaststName { get; set; }
        public long PersonalIndefication { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public AdressDto Address { get; set; }
        public ImageDto Image { get; set; }
        public long PhoneNumber { get; set; }
    }
}
