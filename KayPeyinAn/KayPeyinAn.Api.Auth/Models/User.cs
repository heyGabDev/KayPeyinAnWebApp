using Microsoft.AspNetCore.Identity;

namespace KayPeyinAn.Api.Auth.Models
{
    public class User : IdentityUser
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; } = string.Empty;
    }
}
