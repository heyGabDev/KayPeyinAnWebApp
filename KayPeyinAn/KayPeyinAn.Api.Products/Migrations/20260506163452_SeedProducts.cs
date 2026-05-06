using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace KayPeyinAn.Api.Products.Migrations
{
    /// <inheritdoc />
    public partial class SeedProducts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Available", "CreatedAt", "ImageUrl", "Product_Category", "Product_Description", "Product_Name", "Product_Price", "Product_Stock", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, true, null, "assets/images/baguette.png", 0, "Baguette artisanale, croquante à l'extérieur et tendre à l'intérieur.", "Baguette Tradition", 3.37m, 100, null },
                    { 2, true, null, "assets/images/pain_complet.png", 0, "Pain complet fait maison, riche en fibres et au goût authentique.", "Pain Complet", 1.52m, 100, null },
                    { 3, true, null, "assets/images/pain_nordique.png", 0, "Pain de Nordique fait maison, avec une mie aérée et une croûte dorée.", "Pain de Nordique", 6.20m, 100, null },
                    { 4, true, null, "assets/images/beignet_pomme.png", 1, "Beignet aux pommes légèrement sucré, parfait pour un goûter.", "Beignet aux pommes", 4.23m, 100, null },
                    { 5, true, null, "assets/images/baguette_sesame.png", 0, "Baguette artisanale, croquante à l'extérieur et tendre à l'intérieur.", "Baguette Sésame", 6.36m, 100, null },
                    { 6, true, null, "assets/images/baguette_graines.png", 0, "Baguette multi-graines, riche en saveurs et idéal pour le petit déjeuner.", "Baguette multi-graines", 3.61m, 100, null },
                    { 7, true, null, "assets/images/pain_chocolat.png", 0, "Pain de chocolat fondant dans une pâte feuilletée dorée.", "Pain de Chocolat", 5.98m, 100, null },
                    { 8, true, null, "assets/images/cake_nature.png", 1, "Cake traditionel léger, parfaite pour accompagner le thé.", "Cake nature", 5.76m, 100, null },
                    { 9, true, null, "assets/images/croissant.png", 0, "Croissant au beurre doré, léger et aéré.", "Croissant Beurre", 2.06m, 100, null },
                    { 10, true, null, "assets/images/eclair_chocolat.png", 1, "Éclair au chocolat avec une crème pâtissière onctueuse et un glaçage fondant.", "Éclair au Chocolat", 5.80m, 100, null },
                    { 11, true, null, "assets/images/macaron_pistache_fraise.png", 1, "Macaron à la framboise avec un coeur crémeux et un goût sucré.", "Macaron Framboise", 5.36m, 100, null },
                    { 12, true, null, "assets/images/tarte_citron.png", 1, "Tartelette au citron acidulée avec une crème légère et une pâte croquante.", "Tartelette Citron", 5.01m, 100, null },
                    { 13, true, null, "assets/images/eclair_chocolat.png", 1, "Muffin au chocolat, moelleux et savoureux.", "Muffin Chocolat", 4.46m, 100, null },
                    { 14, true, null, "assets/images/tarte_normande.png", 1, "Tarte Normande faite maison avec une pâte sablée et des pommes caramélisées.", "Tarte Normande", 3.79m, 100, null },
                    { 15, true, null, "assets/images/tartelette_fraises.png", 1, "Tartelette aux fraises fraîches avec une crème pâtissière légère.", "Tartelette Fraise", 3.50m, 100, null },
                    { 16, true, null, "assets/images/pain_raisins.png", 0, "Pain aux raisin, sucrée et fourrée au chocolat fondant dans une pâte feuilletée.", "Pain aux raisins", 2.70m, 100, null },
                    { 17, true, null, "assets/images/madeleine.png", 1, "Madeleine moelleuse au beurre, délicieusement parfumée.", "Madeleine", 1.20m, 100, null },
                    { 18, true, null, "assets/images/chausson_pommes.png", 0, "Chausson aux pommes, fait maison avec une pâte feuilletée légère.", "Chausson aux Pommes", 6.35m, 100, null },
                    { 19, true, null, "assets/images/sandwich_poulet_avocat.png", 2, "Sandwich au poulet grillé avec une sauce César crémeuse.", "Sandwich Poulet Avocat", 4.23m, 100, null },
                    { 20, true, null, "assets/images/tarte_sale.png", 2, "Quiche Lorraine faite maison, avec des lardons, du fromage et des oeufs.", "Quiche Lorraine", 4.36m, 100, null },
                    { 21, true, null, "assets/images/pizza.png", 2, "Pizza Margherita avec une sauce tomate maison et de la mozzarella fondante.", "Pizza Margherita", 5.76m, 100, null },
                    { 22, true, null, "assets/images/wrap.png", 2, "Wrap garni de saumon fumé, fromage frais et laitue croquante.", "Wrap Saumon", 4.87m, 100, null },
                    { 23, true, null, "assets/images/sandwich_jambon_fromage.png", 2, "Sandwich jambon-fromage servi dans une baguette fraîche.", "Sandwich Jambon Fromage", 4.92m, 100, null },
                    { 24, true, null, "assets/images/panini.png", 2, "Panini garnie aux choix.", "Panini", 2.62m, 100, null },
                    { 25, true, null, "assets/images/crepe_sucree.png", 2, "Crêpe épaisse et moelleuse, garnie de confiture maison.", "Crêpe sucrée", 2.13m, 100, null },
                    { 26, true, null, "assets/images/crepe_salee.png", 2, "Crêpe épaisse et moelleuse.", "Crêpe salée", 6.23m, 100, null },
                    { 27, true, null, "assets/images/salade_cesar.png", 2, "Salade César avec poulet grillé, laitue et sauce maison.", "Salade César", 5.39m, 100, null },
                    { 28, true, null, "assets/images/tarte_sale.png", 2, "Tartes salées garnies de légumes de saison et d'une pâte feuilletée.", "Tartes Salées", 4.02m, 100, null },
                    { 29, true, null, "assets/images/latte_macaron_cafe.png", 3, "Café latte crémeux, fait avec du lait mousseux et un espresso corsé.", "Café Latte", 4.51m, 100, null },
                    { 30, true, null, "assets/images/jus_oranges.png", 3, "Jus d'orange frais pressé, plein de vitamines.", "Jus d'Orange Frais", 5.04m, 100, null },
                    { 31, true, null, "assets/images/smoothie_fraise.png", 3, "Smoothie aux fraises fraîches, délicieux et rafraîchissant.", "Smoothie Fraise", 6.38m, 100, null },
                    { 32, true, null, "assets/images/cafe.png", 3, "Café expresso corsé et intense.", "Café Expresso", 2.41m, 100, null },
                    { 33, true, null, "assets/images/cappuccino.png", 3, "Cappuccino onctueux et parfait pour les gourmands.", "Cappuccino", 5.79m, 100, null },
                    { 34, true, null, "assets/images/chocolat_chaud.png", 3, "Chocolat chaud crémeux, idéal pour se réchauffer pendant l'hiver.", "Chocolat Chaud", 2.04m, 100, null },
                    { 35, true, null, "assets/images/jus_pommes.png", 3, "Jus de pomme naturel.", "Jus de Pomme", 4.23m, 100, null },
                    { 36, true, null, "assets/images/pulco_citronnade.png", 3, "Citronnade sucrée et rafraîchissante.", "Pulco citronnade", 1.53m, 100, null },
                    { 37, true, null, "assets/images/fuzetea_peche.png", 3, "Thé glacé peche, léger et désaltérant.", "Boisson Thé Glacé", 3.79m, 100, null },
                    { 38, true, null, "assets/images/fromage_blanc_pommes.png", 2, "Fromage blanc frais avec sa compote de pommes maison, douce et onctueuse.", "Fromage blanc et compote de pommes", 3.48m, 100, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 38);
        }
    }
}
