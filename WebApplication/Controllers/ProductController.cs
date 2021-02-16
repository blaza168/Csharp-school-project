using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Products;
using Shop.Application.Products.Requests;
using WebApplication.Commands.Products;

namespace WebApplication.Controllers
{
    [Route("/api/[controller]")]
    public class ProductController : Controller
    {
        [HttpGet("{productId}")]
        public IActionResult Index(int productId, [FromServices] GetProduct getProduct)
        {
            return Json(getProduct.Do(productId));
        }

        [HttpGet("list")]
        public IActionResult List([FromServices] GetProducts getProducts)
        {
            return Json(getProducts.Do());
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromServices] CreateProduct createProduct, [FromBody] CreateProductRequest request)
        {
            bool success = await createProduct.Do(request) > 0;
            if (success)
            {
                return Ok();
            }
            
            return BadRequest();
        }
    }
}