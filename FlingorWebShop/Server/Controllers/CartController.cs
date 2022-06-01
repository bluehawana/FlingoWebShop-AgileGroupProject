using FlingorWebShop.Server.DAL;
using FlingorWebShop.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FlingorWebShop.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly CartRepository _cartRepository;

        public CartController(CartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        } 

        [HttpGet("{userId}")]
        public async Task<ActionResult<List<ProductDto>>> GetCartAsync(int userId)
        {
            var cart = await _cartRepository.GetCartAsync(userId);
            return cart is null ? NotFound() : Ok(cart);
        }

        [HttpGet]
        public async Task<ActionResult<List<CartDto>>> GetCartAllAsync()
        {
            return Ok(await _cartRepository.GetAllActiveCartsAsync());
        }

        [HttpPost("{userId}")]
        public async Task<ActionResult> PostCartAsync(int userId, [FromBody]List<ProductDto> cart)
        {
            return await _cartRepository.SaveCartAsnyc(cart, userId) ? Ok() : BadRequest();
        }
    }
}
