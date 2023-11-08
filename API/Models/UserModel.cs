using API.Dtos;

namespace API.Models
{
    public class UserModel
    {
        public int? Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public UserDTO ToUserDto()
        {
            return new UserDTO()
            {
                Id = Id ?? throw new Exception("El id no puede ser null"),
                Email = Email,
                Password = Password
            };
        }

        public NewUserDTO ToNewUserDto()
        {
            return new NewUserDTO()
            {
                Email = Email,
                Password = Password
            };
        }
    }
}
