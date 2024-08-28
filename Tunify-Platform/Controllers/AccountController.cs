using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tunify_Platform.Models.DTO;
using Tunify_Platform.Repositories.InterFace;
using Tunify_Platform.Repositories.Services;

namespace Tunify_Platform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccount _account;
        public AccountController(IAccount account)
        {
            _account = account;
        }

        [HttpPost("Register")]

        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            var user = await _account.Register(registerDto);
            if (user == null)
            {
                return Unauthorized();
            }
            return user;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            try
            {
                var result = await _account.Login(loginDto);
                return Ok(result);
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(ex.Message);
            }
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await _account.LogoutAsync();
            return Ok("User logged out successfully.");
        }
       
        [Authorize(Roles = "Admin")]
        [HttpGet("Profile")]
        public async Task<ActionResult<UserDto>> Profile()
        {
            return await _account.userProfile(User);

        }
    }
}
