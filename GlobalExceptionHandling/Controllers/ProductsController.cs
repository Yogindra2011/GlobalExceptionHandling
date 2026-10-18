using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GlobalExceptionHandling.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        
        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(new[]
            {
                new { Id = 1, Name = "Laptop", Price = 50000 },
                new { Id = 2, Name = "Mouse", Price = 500 }
            });
        }

        [HttpGet("error")]
        public IActionResult TestError()
        {
            throw new Exception("Database connection failed!");

            // This exception is intentionally thrown for testing.
        }
    }
}
