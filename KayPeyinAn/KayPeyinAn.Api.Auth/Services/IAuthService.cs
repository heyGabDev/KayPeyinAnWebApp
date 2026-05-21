using KayPeyinAn.Api.Auth.DTOs;
using NuGet.Common;

namespace KayPeyinAn.Api.Auth.Services
{
    public interface IAuthService
    {
        Task<string?> RegisterAsync(RegisterDto registerDto);

        Task<string?> LoginAsync(LoginDto loginDto);

    }
}
