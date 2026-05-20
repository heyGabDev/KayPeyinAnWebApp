using KayPeyinAn.Api.Auth.Models;

namespace KayPeyinAn.Api.Auth.Services
{
    public interface IUserService
    {
        public Task<IEnumerable<User>> GetAllUsersAsync();

        public Task<User?> GetUserByIdAsync(string id); // string car IdentityUser utilise string pour l'Id
    }
}
