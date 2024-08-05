using Microsoft.AspNetCore.Mvc;
using MinimalAPI.Models;
using MinimalAPI.Services;

namespace MinimalAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class OrderController : ControllerBase
    {

        private readonly OrderService orderService;

        public OrderController(OrderService orderService) => this.orderService = orderService;

        [HttpGet]
        public async Task<List<Order>> GetList() => await orderService.GetOrders();

        [HttpGet("{id}")]
        public async Task<Order> Get(string id) => await orderService.GetOrderAsync(id);

        [HttpPost]
        public async Task Post(Order order) => await orderService.CreateAsync(order);

        [HttpPut]
        public async Task Update(string id, Order order) => await orderService.UpdateAsync(id, order);

        [HttpDelete]
        public async Task Delete(string id) => await orderService.RemoveAsync(id);
    }
}
