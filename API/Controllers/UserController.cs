using API.Dtos;
using API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            this._userService = userService; 
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<UserDTO> result = await _userService.Get();
            return new OkObjectResult(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            UserDTO? result = await _userService.Get(id);
            return result != null ? Ok(result) : NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            _userService.Delete(id);
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewUserDTO newUserDto)
        {
            UserDTO? user = await _userService.Create(newUserDto);
            return CreatedAtAction(nameof(Get), new { id = user?.Id }, user);
        }

    }
}
