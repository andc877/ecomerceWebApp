using EcomerceWebAPIs.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcomerceWebAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly EcomerceWebApisDbcontext _dbContext;
        public CategoryController(EcomerceWebApisDbcontext dbContext) { _dbContext = dbContext; }
        [HttpGet("GetCategories")]
        public async Task<ActionResult<IEnumerable<Categories>>> GetCategories()
        {
            if (_dbContext.Users == null)
            {
                return NotFound();
            }
            return await _dbContext.Categories.ToListAsync();

        }

        //public async Task<ActionResult<Categories>> PosBrand(Categories catgories)
        //{
        //    Console.WriteLine("Post brand is initiated...");
        //    _dbContext.Categories.Add(catgories);
        //    await _dbContext.SaveChangesAsync();

        //    return CreatedAtAction(nameof(GetCategories), new { id = catgories.CategoryID }, catgories);
        //}

        [HttpPost("AddCategories")]
        public async Task<ActionResult<IEnumerable<Categories>>> PostProducts(IEnumerable<Categories> catgoryList)
        {
            Console.WriteLine("Post products is initiated...");

            foreach (var category in catgoryList)
            {
                _dbContext.Categories.Add(category);
            }

            await _dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCategories), catgoryList);
        }
    }
}
