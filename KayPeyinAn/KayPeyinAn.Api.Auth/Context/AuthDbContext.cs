using KayPeyinAn.Api.Auth.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KayPeyinAn.Api.Auth.Context
{
    public class AuthDbContext: IdentityDbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder); // ← obligatoire avec Identity !

            builder.Entity<User>()
                .Property(u => u.InternalId)
                .ValueGeneratedOnAdd() // auto-incrément
                .IsRequired(); // non nullable
        }
    }
}
