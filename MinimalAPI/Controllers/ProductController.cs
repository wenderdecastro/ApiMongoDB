using Microsoft.AspNetCore.Mvc;
using MinimalAPI.Models;
using MinimalAPI.Services;

namespace MinimalAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService productService;

        public ProductController(ProductService productService) => this.productService = productService;

        [HttpGet]
        public async Task<List<Product>> GetList() => await productService.GetProducts();

        [HttpGet("{id}")]
        public async Task<Product> Get(string id) => await productService.GetProductAsync(id);

        [HttpPost]
        public async Task Post(Product product) => await productService.CreateAsync(product);

        [HttpPut]
        public async Task Update(string id, Product product) => await productService.UpdateAsync(id, product);

        [HttpDelete]
        public async Task Delete(string id) => await productService.RemoveAsync(id);
    }
}
