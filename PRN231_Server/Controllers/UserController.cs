using BussinessObjects;
using Microsoft.AspNetCore.Mvc;
using Service;
using Service.Model.Request;

namespace PRN231_Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }
        [HttpPost("Login")]
        public ActionResult Login([FromBody] LoginDto loginDto)
        {
            var user = userService.Login(loginDto.Email, loginDto.Password);
            if (loginDto != null && loginDto.Email != null && loginDto.Password != null)
            {
                if (user != null)
                {
                    return Ok("Login succeed fully!");
                }
                else
                {
                    return BadRequest("You do not have permission to access this function!");
                }
            }
            else {
                return BadRequest("You do not have permission to access this function!");
            }
        }

        [HttpPost("SignUp")]
        public ActionResult SignUp([FromBody] RegisterDto registerDto) {
            if (registerDto != null)
            {
                userService.AddUser(registerDto);
                return new CreatedAtActionResult(nameof(SignUp), "User", new { Email = registerDto.Email }, registerDto);
            }
            else { 
                return BadRequest("User signs up fail!!");
            }
        }
    }
    
}
