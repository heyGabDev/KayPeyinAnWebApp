using Microsoft.AspNetCore.Identity;

namespace KayPeyinAn.Api.Auth.Models
{
    public class Role : IdentityRole
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsActive { get; set; }
    }
}
