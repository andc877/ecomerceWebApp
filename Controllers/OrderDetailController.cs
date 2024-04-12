using EcomerceWebAPIs.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcomerceWebAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private readonly EcomerceWebApisDbcontext _dbContext;
        public OrderDetailController(EcomerceWebApisDbcontext dbContext) { _dbContext = dbContext; }
        [HttpGet("GetOrderDetails")]
        public async Task<ActionResult<IEnumerable<OrderDetails>>> GetOrderDetails()
        {
            if (_dbContext.Orders == null)
            {
                return NotFound();
            }
            return await _dbContext.OrderDetails.ToListAsync();

        }

        [HttpPost("AddOrderDetails")]
        public async Task<ActionResult<IEnumerable<OrderDetails>>> PostProducts(IEnumerable<OrderDetails> ordersDetailsList)
        {
            Console.WriteLine("Post products is initiated...");

            foreach (var ordersDetails in ordersDetailsList)
            {
                _dbContext.OrderDetails.Add(ordersDetails);
            }

            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetOrderDetails), ordersDetailsList);
        }
    }
}
