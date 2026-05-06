using System.Collections.Generic;
using System.Threading.Tasks;
using KayPeyinAn.Api.Products.Models;

namespace KayPeyinAn.Api.Products.Services
{
    public interface ICategoryService
    {
        public Task<IEnumerable<Category>> GetAllCategoriesAsync();

        public Task<Category> GetCategoryByIdAsync(int id);
    } 
}

