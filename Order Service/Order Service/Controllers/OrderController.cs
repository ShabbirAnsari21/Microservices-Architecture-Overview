using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Order_Service.Entity;
using Order_Service.Infra;

namespace Order_Service.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        // GET: api/order
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            var orders = await _orderRepository.GetAll();
            return Ok(orders);
        }

        // GET: api/order/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            var order = await _orderRepository.GetById(id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }

        // POST: api/order
        [HttpPost]
        public async Task<ActionResult<Order>> CreateOrder(Order order)
        {
            await _orderRepository.CreateOrder(order);
            return CreatedAtAction(nameof(GetOrder), new { id = order.OrderId }, order);
        }

        // PUT: api/order/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateOrder(int id, Order order)
        //{
        //    if (id != order.OrderId)
        //    {
        //        return BadRequest();
        //    }

        //    await _orderRepository.UpdateOrder(order);
        //    return NoContent();
        //}

        //// DELETE: api/order/5
        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeleteOrder(int id)
        //{
        //    await _orderRepository.DeleteOrder(id);
        //    return NoContent();
        //}
    }
}
