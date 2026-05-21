using KayPeyinAn.Api.Auth.DTOs;
using KayPeyinAn.Api.Auth.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace KayPeyinAn.Api.Auth.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            var token = await _authService.RegisterAsync(registerDto);
            if (token == null)
                return BadRequest("Registration failed.");

            return Ok(new { Token = token });
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
            var token = await _authService.LoginAsync(loginDto);
            if (token == null)
                return Unauthorized("Invalid credentials.");

            return Ok(new { Token = token });
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            // For JWT-based authentication, logout is typically handled on the client side by deleting the token.
            // TODO : implémenter une blacklist de tokens en BDD pour invalidation côté serveur
            var token = Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            if (token == null)
              return BadRequest("No token provided.");

            return Ok("Logout successful.");
        }

        [Authorize]
        [HttpGet("profile")]
        public IActionResult GetProfile()
        {
            // User.FindFirst() lit les claims du token JWT
            var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var email = User.FindFirst(ClaimTypes.Email)?.Value;
            var firstName = User.FindFirst("firstName")?.Value;
            var lastName = User.FindFirst("lastName")?.Value;

            return Ok(new { userId, email, firstName, lastName });
        }
    }
}