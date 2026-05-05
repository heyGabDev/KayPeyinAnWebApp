using KayPeyinAn.Api.Products.Models;
using Microsoft.EntityFrameworkCore;

namespace KayPeyinAn.Api.Products.Data
{
    /// <summary>
    /// Represents the Entity Framework Core database context for the application, providing access to the application's
    /// data model and database operations.
    /// </summary>
    /// <remarks>Use this context to query and save instances of the application's entities. Typically, an
    /// instance of this class is configured and managed by dependency injection. The context manages the connection to
    /// the database and tracks changes to entities.</remarks>
    // Hérite de DbContext
    // Déclare tes DbSet<Product>(= tes tables)
    // Reçoit les options de connexion via le constructeur
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(p => p.Product_Price)
                .HasPrecision(18, 2); // 18 chiffres total, 2 après la virgule
        }
    }
}
