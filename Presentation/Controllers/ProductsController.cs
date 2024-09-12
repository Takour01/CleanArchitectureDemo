using Application.Services;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductsController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> Get()
        {
            return await _productService.GetAllProductsAsync();
        }

        [HttpGet("{id}")]
        public async Task<Product> Get(int id)
        {
            return await _productService.GetProductByIdAsync(id);
        }

        [HttpPost]
        public async Task Post([FromBody] Product product)
        {
            await _productService.AddProductAsync(product);
        }

        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] Product product)
        {
            product.Id = id;
            await _productService.UpdateProductAsync(product);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _productService.DeleteProductAsync(id);
        }
    }
}
