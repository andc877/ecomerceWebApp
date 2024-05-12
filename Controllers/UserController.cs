using EcomerceWebAPIs.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Diagnostics.Tracing;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using static EcomerceWebAPIs.Controllers.Authorization;
using System.Diagnostics;



namespace EcomerceWebAPIs.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        Authorization auth = new Authorization();

        private readonly EcomerceWebApisDbcontext _dbContext;
        public UserController(EcomerceWebApisDbcontext dbContext) { _dbContext = dbContext; }
        [HttpGet("GetAllUsers")]
        [Authorize] // Apply authorization
        public async Task<ActionResult<IEnumerable<Users>>> GetUsers()
        {
            try
            {

                var users = await _dbContext.Users.ToListAsync();

                Console.WriteLine("List of users:");
                foreach (var user in users)
                {
                    Console.WriteLine($"User Id: {user.UserID}, Username: {user.Name}, Email: {user.Email}"); // Adjust properties accordingly
                }
                return users;

            }
            catch (Exception ex)
            {
                // Log the exception or handle it as needed
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }

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

            public string SecretKey { get; set; }

        }

        [HttpPost("Login")]
        public async Task<ActionResult> Login(LoginRequestModel model)
        {

            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == model.Email);

            if (user == null)
            {
                return Unauthorized(new { Credentials = "Email Credentials not matched", LoggedIn = false, id = "null" });  // Credentials are not valid
            }

            var passwordMatched = await _dbContext.Users.AnyAsync(u => u.Email == model.Email && u.Password == model.Password);

            if (passwordMatched)
            {
                //Authorization auth = new Authorization(model.SecretKey);
                auth.SetAuthorization(model.SecretKey);
                var token = auth.GenerateJwtToken(user.UserID, user.Name);
                return Ok(new { token });
                //return Ok(new { User = user, LoggedIn = true }); // Credentials are correct, return user object and loggedIn status
            }
            else
            {
                return Unauthorized(new { Credentials = "Password Credentials not matched", LoggedIn = false, id = "null" });  // Credentials are not valid
            }
        }
        //private string GenerateJwtToken(string username)
        //{
        //    var tokenHandler = new JwtSecurityTokenHandler();
        //    var key = Encoding.ASCII.GetBytes("bd972db7de14db84d7384731760dcec33f618138b7804d0ee6926d452d376981");
        //    var tokenDescriptor = new SecurityTokenDescriptor
        //    {
        //        Subject = new ClaimsIdentity(new[]
        //        {
        //        new Claim(ClaimTypes.Name, username)
        //    }),
        //        Expires = DateTime.UtcNow.AddHours(1), // Token expiration time
        //        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        //    };
        //    var token = tokenHandler.CreateToken(tokenDescriptor);
        //    return tokenHandler.WriteToken(token);
        //}

        [HttpPost("GetUserId")]
        public IActionResult GetUserId()
        {
            try
            {
                var authorizationToken = HttpContext.Request.Headers["Authorization"];
                Debug.WriteLine("anand chauna ");
                Debug.WriteLine($"authorizationToken is {authorizationToken}");
              //  return Ok(new { token  = authorizationToken });

                var userId = auth.GetIdByToken(authorizationToken);

                if (userId != -1)
                {
                    return Ok(new { UserId = userId });
                }
                else
                {
                    return Unauthorized(); // Return 401 Unauthorized if token validation fails
                }
            }
            catch
            {
                return StatusCode(500, "Internal server error");
            }


        }
    }
}