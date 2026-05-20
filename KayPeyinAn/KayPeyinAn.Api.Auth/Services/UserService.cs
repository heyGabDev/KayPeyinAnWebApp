using KayPeyinAn.Api.Auth.Context;
using KayPeyinAn.Api.Auth.Models;
using Microsoft.EntityFrameworkCore;

namespace KayPeyinAn.Api.Auth.Services
{
    public class UserService : IUserService
    {
        private readonly AuthDbContext _context;

        public UserService(AuthDbContext context)
        {
            _context = context;
        }

        async Task<IEnumerable<User>> IUserService.GetAllUsersAsync()
        {
            return (IEnumerable<User>)await _context.Users.ToListAsync();
        }

        async Task<User?> IUserService.GetUserByIdAsync(string id)
        {
            return (User?)await _context.Users.FindAsync(id);
        }
    }
}
