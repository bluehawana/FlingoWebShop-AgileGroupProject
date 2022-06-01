using FlingorWebShop.Server.DAL;
using FlingorWebShop.Shared;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FlingorWebShop.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly OrderRepository _orderRepository;

        public OrderController(OrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<Order>>> GetOrdersAsync()
        {
            var orders = await _orderRepository.GetAllOrdersAsync();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order?>> GetOrderAsync(int id)
        {
            var order = await _orderRepository.GetOrderAsync(id);
            return order is null ? NotFound() : Ok(order);
        }

        //Gets all orders of one specific user.
        [HttpGet("all/{userId}")]
        public async Task<ActionResult<Order?>> GetAllOrderOfOneUserAsync(int userId)
        {
            var order = await _orderRepository.GetAllOrderOfOneUserAsync(userId);
            return order is null ? NotFound() : Ok(order);
        }

        [HttpPost]
        public async Task<ActionResult<Order?>> PostOrderAsync(Order order)
        {
            var result = await _orderRepository.CreateOrder(order);
            return result ? Ok() : BadRequest();
        }
    }
}
