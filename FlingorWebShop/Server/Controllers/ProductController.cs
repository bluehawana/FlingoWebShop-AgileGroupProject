using FlingorWebShop.Server.DAL;
using FlingorWebShop.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlingorWebShop.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize] //Makes all of the calls need authorization.
    public class ProductController : ControllerBase
    {
        private readonly ProductRepository _productRepository;

        public ProductController(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet, AllowAnonymous]
        public async Task<ActionResult<ICollection<Product>>> GetAllAsync()
        {
            var products = await _productRepository.GetAllProductsAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product?>> GetAsync(int id)
        {
            var product = await _productRepository.GetProductAsync(id);
            return product is null ? NotFound() : Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<User?>> PostProductAsync(Product product)
        {
            var result = await _productRepository.CreateProduct(product);
            return result ? Ok() : BadRequest();
        }
    }
}
