using EcomerceWebAPIs.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcomerceWebAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductPriceController : ControllerBase
    {
        private readonly EcomerceWebApisDbcontext _dbContext;
        public ProductPriceController(EcomerceWebApisDbcontext dbContext) { _dbContext = dbContext; }
       
        [HttpGet("GetProductPrice")]
        public async Task<ActionResult<IEnumerable<ProductPrice>>> GetProductPrice()
        {
            if (_dbContext.Users == null)
            {
                return NotFound();
            }
            return await _dbContext.ProductPrice.ToListAsync();

        }

        [HttpPost("AddProductPrices")]
        public async Task<ActionResult<IEnumerable<ProductPrice>>> PostProducts(IEnumerable<ProductPrice> productPriceList)
        {
            Console.WriteLine("Post products is initiated...");

            foreach (var productPrice in productPriceList)
            {
                _dbContext.ProductPrice.Add(productPrice);
            }

            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProductPrice), productPriceList);
        }
    }
}
