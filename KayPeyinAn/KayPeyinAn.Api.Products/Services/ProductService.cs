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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        async Task<IEnumerable<Product>> IProductService.GetAllProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        /// <summary>
        /// Asynchronously retrieves a product with the specified identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the product to retrieve.</param>
        /// <returns></returns>
        async Task<Product?> IProductService.GetProductByIdAsync(int id)
        {
            // better of FirstOrDefaultAsync(p => [p.Id](http://p.Id) == id); 
            return await _context.Products.FindAsync(id);
        }

        ///// <summary>
        ///// Asynchronously retrieves products that belong to the specified category.
        ///// </summary>
        ///// <param name="category"></param>
        ///// <returns></returns>
        //async Task<IEnumerable<Product>> IProductService.GetProductsByCategoryAsync(int category)
        //{
        //    return await _context.Products.Where(p => p.CategoryId == category).ToListAsync();
        //}

        /// <summary>
        /// Asynchronously return 
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="category"></param>
        /// <param name="search"></param>
        /// <returns></returns>
        async Task<IEnumerable<Product>> IProductService.GetProductsPageAsync(int page, int pageSize, int? category, string? search)
        {
            var query = _context.Products.AsQueryable();

            if (category.HasValue)
            {
                query = query.Where(p => p.CategoryId == category.Value);
            }

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(p => p.Product_Name.Contains(search));
            }

            return await query.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
        }
    }
}
