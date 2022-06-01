using FlingorWebShop.Server.DAL;
using FlingorWebShop.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlingorWebShop.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserRepository _userRepository;

        public UserController(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<User>>> GetUsersAsync()
        {
            var users = await _userRepository.GetAllUsersAsync();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User?>> GetUserAsync(int id)
        {
            var user = await _userRepository.GetUserAsync(id);
            return user is null ? NotFound() : Ok(user);
        }

        [HttpGet("find/{email}")]
        public async Task<ActionResult<User?>> GetUserByEmailAsync(string email)
        {
            var user = await _userRepository.GetUserByEmailAsync(email);
            return user is null ? NotFound() : Ok(user);
        }

        [HttpPost]
        public async Task<ActionResult<User?>> PostUserAsync(User user)
        {
            var result = await _userRepository.CreateUser(user);
            return result ? Ok(): BadRequest();
        }
    }
}
