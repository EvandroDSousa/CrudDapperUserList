using CrudDapperUserList.DTO;
using CrudDapperUserList.Services;
using Microsoft.AspNetCore.Mvc;

namespace CrudDapperUserList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserInterface _userInterface;
        public UserController(IUserInterface userInterface)
        {
            _userInterface = userInterface;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _userInterface.GetUserList();

            if (users.Status == false)
            {
                return NotFound(users);
            }

            return Ok(users);
        }

        [HttpGet("{userId}")]
        public async Task<IActionResult> GetUserById(int userId)
        {
            var users = await _userInterface.GetUserById(userId);

            if (users.Status == false)
            {
                return NotFound(users);
            }

            return Ok(users);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserDTO createUserDTO)
        {
            var users = await _userInterface.CreateUser(createUserDTO);

            if (users.Status == false)
            {
                return BadRequest(users);
            }

            return Ok(users);
        }

        [HttpPut]
        public async Task<IActionResult> AlterUser(AlterUserDTO alterUserDTO)
        {
            var users = await _userInterface.AlterUser(alterUserDTO);

            if (users.Status == false)
            {
                return BadRequest(users);
            }

            return Ok(users);
        }

        [HttpDelete("{userId}")]
        public async Task<IActionResult> RemoveUser(int userId)
        {
            var users = await _userInterface.RemoveUser(userId);

            if (users.Status == false)
            {
                return BadRequest(users);
            }

            return Ok(users);
        }
    }
}