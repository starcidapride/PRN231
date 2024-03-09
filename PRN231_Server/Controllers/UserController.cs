using BussinessObjects;
using Microsoft.AspNetCore.Mvc;
using Service;
using Service.Model.Request;
using Service.Model.Response;

namespace PRN231_Server.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController : Controller
    {
        private IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }


        [HttpPost("login")]
        public ActionResult Login([FromBody] LoginDto loginDto)
        {
            var user = userService.Login(loginDto.Email, loginDto.Password);
            if (loginDto != null && loginDto.Email != null && loginDto.Password != null)
            {
                if (user != null)
                {
                    return Ok(user);
                }
                else
                {
                    return BadRequest("You do not have permission to access this function!");
                }
            }
            else
            {
                return BadRequest("You do not have permission to access this function!");
            }
        }

        [HttpPost("signup")]
        public ActionResult SignUp([FromBody] RegisterDto registerDto)
        {
            if (registerDto != null)
            {
                userService.AddUser(registerDto);
                return new CreatedAtActionResult(nameof(SignUp), "User", new { Email = registerDto.Email }, registerDto);
            }
            else
            {
                return BadRequest("User signs up fail!!");
            }
        }

        [HttpPut("/updatebyname")]
        public ActionResult EditUser([FromBody] EditUserDto editUserDto)
        {
            if (editUserDto != null)
            {
                var user = userService.EditUser(editUserDto);
                if (user == null)
                {
                    return BadRequest("Edit user fail!!");
                }
                return Ok(user);
            }
            else
            {
                return BadRequest("Edit user fail!!");
            }
        }

        [HttpDelete("/deactivate")]
        public ActionResult DeactivateUser(Guid id)
        {
            if (id != null)
            {
                var user = userService.ActiveUser(id, false);
                if (user == null) {
                    return BadRequest("Deactivate fail!!");
                }
                return Ok(user);
            }
            else
            {
                return BadRequest("Deactivate fail!!");
            }
        }

        [HttpPost("/activate")]
        public ActionResult ActivateUser(Guid id)
        {
            if (id != null)
            {
                var user = userService.ActiveUser(id, true);
                if (user == null)
                {
                    return BadRequest("Activate fail!!");
                }
                return Ok(user);
            }
            else
            {
                return BadRequest("Activate fail!!");
            }
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var listUser = userService.GetAllUser();
            if (listUser != null)
            {
                return Ok(listUser);
            }
            else
            {
                return NotFound("List user is null!");
            }
        }


        [HttpGet("{id}/getId")]
        public ActionResult GetById(Guid id)
        {
            var user = userService.GetUserById(id);

            if (user != null)
            {
                return Ok(user);
            }
            else
            {
                return NotFound("There is no user exit with this id: " + id);
            }
        }


        [HttpGet("{email}/getEmail")]
        public ActionResult GetByEmail(string email)
        {
            var user = userService.GetUserByEmail(email);
            if (user != null)
            {
                return Ok(user);
            }
            else
            {
                return NotFound("There is no user exit with this email: " + email);
            }
        }


        [HttpGet("{username}/getName")]
        public ActionResult GetByUsername(string username)
        {
            var user = userService.GetUserByUsername(username);
            if (user != null)
            {
                return Ok(user);
            }
            else
            {
                return NotFound("There is no user exit with this username: " + username);
            }
        }

    }

}
