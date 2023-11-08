using API.Dtos;
using API.Models;
using API.Repositories;

namespace API.Services
{
    public class UserService
    {
        private readonly UserContext context;

        public UserService(UserContext context)
        {
            this.context = context;
        }

        public async Task<List<UserDTO>> Get()
        {
            return context.Get().Result.Select(u => u.ToUserDto()).ToList();
        }
        
        public async Task<UserDTO?> Get(int id)
        {
            UserModel? result = await context.Get(id);
            return result?.ToUserDto();
        }

        public async Task<UserDTO?> Create(NewUserDTO userDto)
        {
            UserModel newUser = new UserModel()
            {
                Id = null,
                Email = userDto.Email,
                Password = userDto.Password,
            };

            UserModel entity = await context.Create(newUser);
            return entity?.ToUserDto();
        }

        public void Delete(int id)
        {
            context.Delete(id);
        }
    }
}
