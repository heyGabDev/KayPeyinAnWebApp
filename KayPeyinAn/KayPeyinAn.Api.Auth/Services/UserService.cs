using KayPeyinAn.Api.Auth.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace KayPeyinAn.Api.Auth.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> _userManager;

        public UserService(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        async Task<IEnumerable<User>> IUserService.GetAllUsersAsync()
        {
            return await _userManager.Users.ToListAsync();
        }

        async Task<User?> IUserService.GetUserByIdAsync(string id)
        {
            return await _userManager.FindByIdAsync(id);
        }
    }
}
