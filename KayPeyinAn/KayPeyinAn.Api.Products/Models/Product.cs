namespace KayPeyinAn.Api.Products.Models
{
    /// <summary>
    /// Represents a product with details such as name, price, quantity, category, and availability.
    /// </summary>
    /// <remarks>The Product class encapsulates information commonly associated with items in a catalog or
    /// inventory system, including metadata such as creation and update timestamps. Property values should be set
    /// according to the requirements of the consuming application. The class does not enforce validation on property
    /// values; callers are responsible for ensuring data integrity as needed.</remarks>
    public class Product
    {
        /// <summary>
        /// 
        /// </summary>
        public int Id { get; set; }
        
        /// <summary>
        /// Gets or sets the name of the product.
        /// </summary>
        public string Product_Name { get; set; } = string.Empty;        
        
        /// <summary>
        /// Gets or sets the price of the product.
        /// </summary>
        public decimal Product_Price { get; set; }

        /// <summary>
        /// Gets or sets the available stock quantity for the product.
        /// </summary>
        public int Product_Stock { get; set; }
        
        /// <summary>
        /// Gets or sets the URL of the image associated with product.
        /// </summary>
        public string ImageUrl { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the category associated with the product.
        /// </summary>
        // Clé étrangère vers la table Category
        public int CategoryId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        // Navigation property — EF Core fait la jointure automatiquement
        public Category Product_Category { get; set; } = null!;

        /// <summary>
        /// Gets or sets the description of the product.
        /// </summary>
        public string Product_Description { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets a value indicating whether the item is available.
        /// </summary>
        public bool? Available { get; set; }
        
        /// <summary>
        /// Gets or sets the date and time when the entity was created.
        /// </summary>
        public DateTime? CreatedAt { get; set; }
        
        /// <summary>
        /// Gets or sets the date and time when the entity was last updated.
        /// </summary>
        public DateTime? UpdatedAt { get; set; }

    }

}
