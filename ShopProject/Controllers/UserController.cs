using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopProject.Services.UserService;
using System.Diagnostics;

namespace ShopProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {

            _userService = userService;

        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(UserRegister userRegister)
        {

            _userService.Create(userRegister);

            return Ok();

        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(UserLogin userlogin)
        {

            var result = _userService.Login(userlogin);

            if (result == null)
            {
                return BadRequest("Username or password not found");
            }

            return Ok(result);

        }
    }
}
