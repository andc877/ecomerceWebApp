using EcomerceWebAPIs.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcomerceWebAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly EcomerceWebApisDbcontext _dbContext;
        public ProductController(EcomerceWebApisDbcontext dbContext) { _dbContext = dbContext; }
        [HttpGet("GetProducts")]
        public async Task<ActionResult<IEnumerable<Products>>> GetProducts()
        {
            if (_dbContext.Users == null)
            {
                return NotFound();
            }
            return await _dbContext.Products.ToListAsync();

        }

        [HttpPost("AddProducts")]
        public async Task<ActionResult<IEnumerable<Products>>> PostProducts(IEnumerable<Products> productsList)
        {
            Console.WriteLine("Post products is initiated...");

            foreach (var product in productsList)
            {
                _dbContext.Products.Add(product);
            }

            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProducts), productsList);
        }

    }
}
