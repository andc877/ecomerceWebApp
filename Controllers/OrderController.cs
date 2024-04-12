using EcomerceWebAPIs.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcomerceWebAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly EcomerceWebApisDbcontext _dbContext;
        public OrderController(EcomerceWebApisDbcontext dbContext) { _dbContext = dbContext; }
        [HttpGet("GetOrders")]
        public async Task<ActionResult<IEnumerable<Orders>>> GetOrders()
        {
            if (_dbContext.Orders == null)
            {
                return NotFound();
            }
            return await _dbContext.Orders.ToListAsync();

        }

        [HttpPost("OrderPlace")]
        public async Task<ActionResult<IEnumerable<Orders>>> PostProducts(IEnumerable<Orders> ordersList)
        {
            Console.WriteLine("Post products is initiated...");

            foreach (var order in ordersList)
            {
                _dbContext.Orders.Add(order);
            }

            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOrders), ordersList);
        }

    }
}
