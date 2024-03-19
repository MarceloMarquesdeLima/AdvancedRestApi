using AdvancedRestApi.Interfaces;
using AdvancedRestApi.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AdvancedRestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUser _userService;

        public UserController(IUser userService)
        {
            _userService = userService;
        }

        // GET: api/<UserController>
        [HttpGet]
        public async Task<IEnumerable<User>> Get()
        {
            return await _userService.GetAllUsers();
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<User> Get(Guid id)
        {
            return await _userService.GetUserById(id);
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task Post([FromBody] User user)
        {
            await _userService.AddUser(user);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task Put(Guid id, [FromBody] User user)
        {
            await _userService.UpdateUser(id, user);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task Delete(Guid id)
        {
            await _userService.DeleteUser(id);
        }
    }
}
