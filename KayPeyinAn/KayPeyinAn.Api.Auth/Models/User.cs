using Microsoft.AspNetCore.Identity;

namespace KayPeyinAn.Api.Auth.Models
{
    public class User : IdentityUser
    {
        // Id, Email, Username, PasswordHash...ds IdentityUser natif
        public int InternalId { get; set; } // Id interne  pour BDD !!! ne jamais exposé ds API - servira ds le cadre des KPI et jointure
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        
    }
}
