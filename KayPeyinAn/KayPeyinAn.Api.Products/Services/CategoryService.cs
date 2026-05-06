using KayPeyinAn.Api.Products.Data;
using KayPeyinAn.Api.Products.Models;
using Microsoft.EntityFrameworkCore;

namespace KayPeyinAn.Api.Products.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly AppDbContext _context;

        public CategoryService(AppDbContext context)
        {
            _context = context;
        }

        async Task<IEnumerable<Category>> ICategoryService.GetAllCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        async Task<Category> ICategoryService.GetCategoryByIdAsync(int id)
        {
            return await _context.Categories.Where(c => (int)c.Id == id).FirstOrDefaultAsync();
        }
    }
}
