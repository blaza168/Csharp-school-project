using Microsoft.AspNetCore.Mvc;
using Shop.Application.Products;

namespace WebApplication.Controllers
{
    [Route("[controller]")]
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
    }
}