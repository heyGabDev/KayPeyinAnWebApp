using KayPeyinAn.Api.Products.Models;

namespace KayPeyinAn.Api.Products.Services
{
    public interface IProductService
    {
        public Task<IEnumerable<Product>> GetAllProductsAsync();

        public Task<Product?> GetProductByIdAsync(int id);
        
        public Task<IEnumerable<Product>> GetProductsByCategoryAsync(int category);
    }
}
