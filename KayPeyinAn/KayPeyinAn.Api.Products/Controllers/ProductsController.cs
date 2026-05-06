using KayPeyinAn.Api.Products.Models;
using KayPeyinAn.Api.Products.Services;
using Microsoft.AspNetCore.Mvc;

namespace KayPeyinAn.Api.Products.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Returns all products
        /// </summary>
        /// <returns>An <see cref="IActionResult"/> containing the list of products.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productService.GetAllProductsAsync();
            return Ok(products);
        }

        /// <summary>
        /// Returns a product by its ID
        /// </summary>
        /// <param name="id">The unique identifier of the product to retrieve.</param>
        /// <returns>An <see cref="IActionResult"/> containing the product data if found; otherwise, a NotFound result.</returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpGet("category/{category}")]
        public async Task<IActionResult> GetProductsByCategory(int category)
        {
            var products = await _productService.GetProductsByCategoryAsync(category);
            return Ok(products);
        }
    }
}