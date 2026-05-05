using KayPeyinAn.Api.Products.Data;
using KayPeyinAn.Api.Products.Models;
using Microsoft.EntityFrameworkCore;

namespace KayPeyinAn.Api.Products.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _context;
        public ProductService(AppDbContext context)
        {
            _context = context;
        }

        async Task<IEnumerable<Product>> IProductService.GetAllProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        async Task<Product?> IProductService.GetProductByIdAsync(int id)
        {
            // better of FirstOrDefaultAsync(p => [p.Id](http://p.Id) == id); 
            return await _context.Products.FindAsync(id);
        }
    }
}
