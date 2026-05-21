using KayPeyinAn.Api.Auth.Context;
using KayPeyinAn.Api.Auth.DTOs;
using KayPeyinAn.Api.Auth.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Text;


namespace KayPeyinAn.Api.Auth.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly IConfiguration _configuration;

        public AuthService(UserManager<User> userManager, IConfiguration configuration)
        {
           _userManager = userManager;
            _configuration = configuration;
        }

        public async Task<string?>RegisterAsync(RegisterDto registerDto)
        {
            //1. check password
            if(registerDto.Password != registerDto.ConfirmPassword)
                return null;

            //2. check user by Identity
            var user = new User
            {
                UserName = registerDto.Email,
                Email = registerDto.Email,
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
            };

            var result = await _userManager.CreateAsync(user, registerDto.Password);
            if (!result.Succeeded)
                return null;

            //3. generate token
            return GenerateJwtToken(user);
        }

        public async Task<string?> LoginAsync(LoginDto loginDto)
        {
            //1. check user by Identity 
            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null)
                return null;

            //2. check password
            var isPasswordValid = await _userManager.CheckPasswordAsync(user, loginDto.Password);
            if (!isPasswordValid)
                return null;

            //3. generate token
            return GenerateJwtToken(user);
        }

        #region Private Methods
        /// <summary>
        /// Generates a JSON Web Token (JWT) containing claims for the specified user.
        /// </summary>
        /// <param name="user">The user for whom the JWT will be generated.</param>
        /// <returns>A string representing the generated JWT, encoded and signed according to the configured security settings.</returns>
        private string GenerateJwtToken(User user)
        {
            // Implementation for generating JWT token
            var key = new SymmetricSecurityKey(
                 Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Claims — données embarquées dans le token
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                new Claim(JwtRegisteredClaimNames.Email, user.Email!),
                new Claim("firstName", user.FirstName),
                new Claim("lastName", user.LastName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(
                    double.Parse(_configuration["Jwt:ExpiresInMinutes"]!)),
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"],
                SigningCredentials = credentials
            };

            var handler = new JsonWebTokenHandler();
            return handler.CreateToken(tokenDescriptor);
        }
        #endregion
    }
}
