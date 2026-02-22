using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Application.Abstractions.Services;
using SchoolManagement.Application.RR_Models.User;
using SchoolManagement.Application.RR_Models.User.UserLogin;
using SchoolManagement.Application.Utils;

namespace SchoolManagement.API.Controllers
{
    [ApiController]
    [Route("api/users")]
    public class UserController(IUserService userService) : ControllerBase
    {
        [HttpPost]
        public async Task<Result<UserResponse>> CreateUser(UserRequest model)
        {
            var result = await userService.AddUser(model);
            return result;
        }

        [HttpPost("login")]
        public async Task<Result<LoginResponse>> UserLogin(LoginRequest model)
        {
            var result = await userService.UserLogin(model);
            if(!result.IsSuccess)
            {
                return result;
            }
            var token = result.Value?.Token;
            Response.Cookies.Append("accessToken", token, new CookieOptions
            {
                HttpOnly = true,
                Secure = false, // Set to true in production
                SameSite = SameSiteMode.Strict,
                Expires = DateTimeOffset.UtcNow.AddMinutes(10)
            });
            result.Value?.Token = null;
            return result;
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("accessToken");
            return Ok();
        }
    }
}
