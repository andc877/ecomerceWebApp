using EcomerceWebAPIs.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcomerceWebAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly EcomerceWebApisDbcontext _dbContext;
        public UserController(EcomerceWebApisDbcontext dbContext) { _dbContext = dbContext; }
        [HttpGet("GetAllUsers")]
        public async Task<ActionResult<IEnumerable<Users>>> GetUsers()
        {
            var users = await _dbContext.Users.ToListAsync();

            Console.WriteLine("List of users:");
            foreach (var user in users)
            {
                Console.WriteLine($"User Id: {user.UserID}, Username: {user.Name}, Email: {user.Email}"); // Adjust properties accordingly
            }

            return users;

        }


        [HttpPost("Register")]
        public async Task<ActionResult<Users>> PosBrand(Users user)
        {
            Console.WriteLine("Post brand is initiated...");
            _dbContext.Users.Add(user);
            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetUsers), new { id = user.UserID }, user);
        }
        public class LoginRequestModel
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }

        [HttpPost("Login")]
        public async Task<ActionResult> Login(LoginRequestModel model)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == model.Password);

            if (user == null)
            {
                return Unauthorized(); // Credentials are not valid
            }

            return Ok(user.Name); // Credentials are correct, return user's name
        }
    }
}