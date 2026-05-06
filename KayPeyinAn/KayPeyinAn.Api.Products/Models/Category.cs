namespace KayPeyinAn.Api.Products.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public bool IsActive { get; set; }

        // Liste des produits de cette catégorie
        public ICollection<Product> Products { get; set; } = new List<Product>();

    }
}
