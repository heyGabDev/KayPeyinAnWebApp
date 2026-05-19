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
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Product> Products { get; set; } = null!;

        public DbSet<Category> Categories { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // ─── Seed Categories ──────────────────────────────────
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = 1, Name = "Boulangerie", IsActive = true },
                new Category { Id = 2, Name = "Pâtisserie", IsActive = true },
                new Category { Id = 3, Name = "Snacking", IsActive = true },
                new Category { Id = 4, Name = "Boisson", IsActive = true }
            );

            modelBuilder.Entity<Product>()
                .Property(p => p.Product_Price)
                .HasPrecision(18, 2); // 18 chiffres total, 2 après la virgule

            // ─── Seed Data ────────────────────────────────────────
            // TODO : remplacer par des données réelles en production
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = 1, Product_Name = "Baguette Tradition", CategoryId=1, Product_Price = 3.37m, Product_Stock = 100, Available = true, CreatedAt = new DateTime(2026, 5, 6), ImageUrl = "assets/images/baguette.png", Product_Description = "Baguette artisanale, croquante à l'extérieur et tendre à l'intérieur." },
                new Product { Id = 2, Product_Name = "Pain Complet", CategoryId=1, Product_Price = 1.52m, Product_Stock = 100, Available = true, CreatedAt = new DateTime(2026, 5, 6), ImageUrl = "assets/images/pain_complet.png", Product_Description = "Pain complet fait maison, riche en fibres et au goût authentique." },
                new Product { Id = 3, Product_Name = "Pain de Nordique", CategoryId=1, Product_Price = 6.20m, Product_Stock = 100, Available = true, CreatedAt = new DateTime(2026, 5, 6), ImageUrl = "assets/images/pain_nordique.png", Product_Description = "Pain de Nordique fait maison, avec une mie aérée et une croûte dorée." },
                new Product { Id = 4, Product_Name = "Beignet aux pommes", CategoryId=2, Product_Price = 4.23m, Product_Stock = 100, Available = true, CreatedAt = new DateTime(2026, 5, 6), ImageUrl = "assets/images/beignet_pomme.png", Product_Description = "Beignet aux pommes légèrement sucré, parfait pour un goûter." },
                new Product { Id = 5, Product_Name = "Baguette Sésame", CategoryId=1, Product_Price = 6.36m, Product_Stock = 100, Available = true, CreatedAt = new DateTime(2026, 5, 6), ImageUrl = "assets/images/baguette_sesame.png", Product_Description = "Baguette artisanale, croquante à l'extérieur et tendre à l'intérieur." },
                new Product { Id = 6, Product_Name = "Baguette multi-graines", CategoryId=1, Product_Price = 3.61m, Product_Stock = 100, Available = true, CreatedAt = new DateTime(2026, 5, 6), ImageUrl = "assets/images/baguette_graines.png", Product_Description = "Baguette multi-graines, riche en saveurs et idéal pour le petit déjeuner." },
                new Product { Id = 7, Product_Name = "Pain de Chocolat", CategoryId=1, Product_Price = 5.98m, Product_Stock = 100, Available = true, CreatedAt = new DateTime(2026, 5, 6), ImageUrl = "assets/images/pain_chocolat.png", Product_Description = "Pain de chocolat fondant dans une pâte feuilletée dorée." },
                new Product { Id = 8, Product_Name = "Cake nature", CategoryId=2, Product_Price = 5.76m, Product_Stock = 100, Available = true, CreatedAt = new DateTime(2026, 5, 6), ImageUrl = "assets/images/cake_nature.png", Product_Description = "Cake traditionel léger, parfaite pour accompagner le thé." },
                new Product { Id = 9, Product_Name = "Croissant Beurre", CategoryId=1, Product_Price = 2.06m, Product_Stock = 100, Available = true, CreatedAt = new DateTime(2026, 5, 6), ImageUrl = "assets/images/croissant.png", Product_Description = "Croissant au beurre doré, léger et aéré." },
                new Product { Id = 10, Product_Name = "Éclair au Chocolat", CategoryId=2, Product_Price = 5.80m, Product_Stock = 100, Available = true, CreatedAt = new DateTime(2026, 5, 6), ImageUrl = "assets/images/eclair_chocolat.png", Product_Description = "Éclair au chocolat avec une crème pâtissière onctueuse et un glaçage fondant." },
                new Product { Id = 11, Product_Name = "Macaron Framboise", CategoryId=2, Product_Price = 5.36m, Product_Stock = 100, Available = true, CreatedAt = new DateTime(2026, 5, 6), ImageUrl = "assets/images/macaron_pistache_fraise.png", Product_Description = "Macaron à la framboise avec un coeur crémeux et un goût sucré." },
                new Product { Id = 12, Product_Name = "Tartelette Citron", CategoryId=2, Product_Price = 5.01m, Product_Stock = 100, Available = true, CreatedAt = new DateTime(2026, 5, 6), ImageUrl = "assets/images/tarte_citron.png", Product_Description = "Tartelette au citron acidulée avec une crème légère et une pâte croquante." },
                new Product { Id = 13, Product_Name = "Muffin Chocolat", CategoryId=2, Product_Price = 4.46m, Product_Stock = 100, Available = true, CreatedAt = new DateTime(2026, 5, 6), ImageUrl = "assets/images/eclair_chocolat.png", Product_Description = "Muffin au chocolat, moelleux et savoureux." },
                new Product { Id = 14, Product_Name = "Tarte Normande", CategoryId=2, Product_Price = 3.79m, Product_Stock = 100, Available = true, CreatedAt = new DateTime(2026, 5, 6), ImageUrl = "assets/images/tarte_normande.png", Product_Description = "Tarte Normande faite maison avec une pâte sablée et des pommes caramélisées." },
                new Product { Id = 15, Product_Name = "Tartelette Fraise", CategoryId=2, Product_Price = 3.50m, Product_Stock = 100, Available = true, CreatedAt = new DateTime(2026, 5, 6), ImageUrl = "assets/images/tartelette_fraises.png", Product_Description = "Tartelette aux fraises fraîches avec une crème pâtissière légère." },
                new Product { Id = 16, Product_Name = "Pain aux raisins", CategoryId=1, Product_Price = 2.70m, Product_Stock = 100, Available = true, CreatedAt = new DateTime(2026, 5, 6), ImageUrl = "assets/images/pain_raisins.png", Product_Description = "Pain aux raisin, sucrée et fourrée au chocolat fondant dans une pâte feuilletée." },
                new Product { Id = 17, Product_Name = "Madeleine", CategoryId=2, Product_Price = 1.20m, Product_Stock = 100, Available = true, CreatedAt = new DateTime(2026, 5, 6), ImageUrl = "assets/images/madeleine.png", Product_Description = "Madeleine moelleuse au beurre, délicieusement parfumée." },
                new Product { Id = 18, Product_Name = "Chausson aux Pommes", CategoryId=1, Product_Price = 6.35m, Product_Stock = 100, Available = true, CreatedAt = new DateTime(2026, 5, 6), ImageUrl = "assets/images/chausson_pommes.png", Product_Description = "Chausson aux pommes, fait maison avec une pâte feuilletée légère." },
                new Product { Id = 19, Product_Name = "Sandwich Poulet Avocat", CategoryId=3, Product_Price = 4.23m, Product_Stock = 100, Available = true, CreatedAt = new DateTime(2026, 5, 6), ImageUrl = "assets/images/sandwich_poulet_avocat.png", Product_Description = "Sandwich au poulet grillé avec une sauce César crémeuse." },
                new Product { Id = 20, Product_Name = "Quiche Lorraine", CategoryId=3, Product_Price = 4.36m, Product_Stock = 100, Available = true, CreatedAt = new DateTime(2026, 5, 6), ImageUrl = "assets/images/tarte_sale.png", Product_Description = "Quiche Lorraine faite maison, avec des lardons, du fromage et des oeufs." },
                new Product { Id = 21, Product_Name = "Pizza Margherita", CategoryId=3, Product_Price = 5.76m, Product_Stock = 100, Available = true, CreatedAt = new DateTime(2026, 5, 6), ImageUrl = "assets/images/pizza.png", Product_Description = "Pizza Margherita avec une sauce tomate maison et de la mozzarella fondante." },
                new Product { Id = 22, Product_Name = "Wrap Saumon", CategoryId=3, Product_Price = 4.87m, Product_Stock = 100, Available = true, CreatedAt = new DateTime(2026, 5, 6), ImageUrl = "assets/images/wrap.png", Product_Description = "Wrap garni de saumon fumé, fromage frais et laitue croquante." },
                new Product { Id = 23, Product_Name = "Sandwich Jambon Fromage", CategoryId=3, Product_Price = 4.92m, Product_Stock = 100, Available = true, CreatedAt = new DateTime(2026, 5, 6), ImageUrl = "assets/images/sandwich_jambon_fromage.png", Product_Description = "Sandwich jambon-fromage servi dans une baguette fraîche." },
                new Product { Id = 24, Product_Name = "Panini", CategoryId=3, Product_Price = 2.62m, Product_Stock = 100, Available = true, CreatedAt = new DateTime(2026, 5, 6), ImageUrl = "assets/images/panini.png", Product_Description = "Panini garnie aux choix." },
                new Product { Id = 25, Product_Name = "Crêpe sucrée", CategoryId=3, Product_Price = 2.13m, Product_Stock = 100, Available = true, CreatedAt = new DateTime(2026, 5, 6), ImageUrl = "assets/images/crepe_sucree.png", Product_Description = "Crêpe épaisse et moelleuse, garnie de confiture maison." },
                new Product { Id = 26, Product_Name = "Crêpe salée", CategoryId=3, Product_Price = 6.23m, Product_Stock = 100, Available = true, CreatedAt = new DateTime(2026, 5, 6), ImageUrl = "assets/images/crepe_salee.png", Product_Description = "Crêpe épaisse et moelleuse." },
                new Product { Id = 27, Product_Name = "Salade César", CategoryId=3, Product_Price = 5.39m, Product_Stock = 100, Available = true, CreatedAt = new DateTime(2026, 5, 6), ImageUrl = "assets/images/salade_cesar.png", Product_Description = "Salade César avec poulet grillé, laitue et sauce maison." },
                new Product { Id = 28, Product_Name = "Tartes Salées", CategoryId=3, Product_Price = 4.02m, Product_Stock = 100, Available = true, CreatedAt = new DateTime(2026, 5, 6), ImageUrl = "assets/images/tarte_sale.png", Product_Description = "Tartes salées garnies de légumes de saison et d'une pâte feuilletée." },
                new Product { Id = 29, Product_Name = "Café Latte", CategoryId=4, Product_Price = 4.51m, Product_Stock = 100, Available = true, CreatedAt = new DateTime(2026, 5, 6), ImageUrl = "assets/images/latte_macaron_cafe.png", Product_Description = "Café latte crémeux, fait avec du lait mousseux et un espresso corsé." },
                new Product { Id = 30, Product_Name = "Jus d'Orange Frais", CategoryId=4, Product_Price = 5.04m, Product_Stock = 100, Available = true, CreatedAt = new DateTime(2026, 5, 6), ImageUrl = "assets/images/jus_oranges.png", Product_Description = "Jus d'orange frais pressé, plein de vitamines." },
                new Product { Id = 31, Product_Name = "Smoothie Fraise", CategoryId=4, Product_Price = 6.38m, Product_Stock = 100, Available = true, CreatedAt = new DateTime(2026, 5, 6), ImageUrl = "assets/images/smoothie_fraise.png", Product_Description = "Smoothie aux fraises fraîches, délicieux et rafraîchissant." },
                new Product { Id = 32, Product_Name = "Café Expresso", CategoryId=4, Product_Price = 2.41m, Product_Stock = 100, Available = true, CreatedAt = new DateTime(2026, 5, 6), ImageUrl = "assets/images/cafe.png", Product_Description = "Café expresso corsé et intense." },
                new Product { Id = 33, Product_Name = "Cappuccino", CategoryId=4, Product_Price = 5.79m, Product_Stock = 100, Available = true, CreatedAt = new DateTime(2026, 5, 6), ImageUrl = "assets/images/cappuccino.png", Product_Description = "Cappuccino onctueux et parfait pour les gourmands." },
                new Product { Id = 34, Product_Name = "Chocolat Chaud", CategoryId=4, Product_Price = 2.04m, Product_Stock = 100, Available = true, CreatedAt = new DateTime(2026, 5, 6), ImageUrl = "assets/images/chocolat_chaud.png", Product_Description = "Chocolat chaud crémeux, idéal pour se réchauffer pendant l'hiver." },
                new Product { Id = 35, Product_Name = "Jus de Pomme", CategoryId=4, Product_Price = 4.23m, Product_Stock = 100, Available = true, CreatedAt = new DateTime(2026, 5, 6), ImageUrl = "assets/images/jus_pommes.png", Product_Description = "Jus de pomme naturel." },
                new Product { Id = 36, Product_Name = "Pulco citronnade", CategoryId=4, Product_Price = 1.53m, Product_Stock = 100, Available = true, CreatedAt = new DateTime(2026, 5, 6), ImageUrl = "assets/images/pulco_citronnade.png", Product_Description = "Citronnade sucrée et rafraîchissante." },
                new Product { Id = 37, Product_Name = "Boisson Thé Glacé", CategoryId=4, Product_Price = 3.79m, Product_Stock = 100, Available = true, CreatedAt = new DateTime(2026, 5, 6), ImageUrl = "assets/images/fuzetea_peche.png", Product_Description = "Thé glacé peche, léger et désaltérant." },
                new Product { Id = 38, Product_Name = "Fromage blanc et compote de pommes", CategoryId=3, Product_Price = 3.48m, Product_Stock = 100, Available = true, CreatedAt = new DateTime(2026, 5, 6), ImageUrl = "assets/images/fromage_blanc_pommes.png", Product_Description = "Fromage blanc frais avec sa compote de pommes maison, douce et onctueuse." }
            );
        }
    }
}
