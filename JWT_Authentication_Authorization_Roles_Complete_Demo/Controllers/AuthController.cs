using JWT_Authentication_Authorization_Roles_RefreshToken_Demo.DTOs;
using JWT_Authentication_Authorization_Roles_RefreshToken_Demo.Entities;
using JWT_Authentication_Authorization_Roles_RefreshToken_Demo.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace JWT_Authentication_Authorization_Roles_RefreshToken_Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        [HttpPost("register")]
        public async Task<ActionResult<User>> Register(UserRegisterDTO request)
        {
            var user = await authService.RegisterAsync(request);
            if (user is null) 
                return BadRequest("Username already exists.");

            return Ok(user);
        }

        [HttpPost("login")]
        public async Task<ActionResult<TokenResponseDTO>> Login(UserLoginDTO request)
        {
            var result = await authService.LoginAsync(request);
            if (result is null) 
                return BadRequest("Invalid Username or Password.");

            return Ok(result);
        }

        [HttpPost("refresh-token")]
        public async Task<ActionResult<TokenResponseDTO>> RefreshToken(RefreshTokenRequestDTO request)
        {
            var result = await authService.RefreshTokensAsync(request);
            if (result is null || result.AccessToken is null || result.RefreshToken is null) 
                return Unauthorized("Invalid Refresh Token.");

            return Ok(result);
        }

        // To test this Endpoint first get JWT from logging into system and then
        // provide it in Headers of our Endpoint Key will be Authorization and Value must start with
        // Bearer space JWT or a token that's it.
        [HttpGet]
        [Authorize]
        public IActionResult AuthenticatedUserOnlyEndpoint()
        {
            return Ok("You are Authenticated.");
        }

        // We can add more roles using comma and now we are doing authentication with authorization
        // depending on assigned roles to the users for example below
        //[Authorize(Roles = "Admin, User, Manager etc")]
        [HttpGet("admin-only")]
        [Authorize(Roles = "Admin")]
        public IActionResult AdminOnlyEndpoint()
        {
            return Ok("You are Authenticated and Authorized to use this Endpoint as Admin.");
        }
    }
}
