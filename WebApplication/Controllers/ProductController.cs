using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Products;
using Shop.Application.Products.Requests;

namespace WebApplication.Controllers
{
    [Route("/api/[controller]")]
    public class ProductController : Controller
    {
        [HttpGet("{productId}")]
        public IActionResult GetProduct([FromServices] GetProduct getProduct, int productId)
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

        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromServices] UpdateProduct updateProduct,
            UpdateProductRequest updateProductRequest)
        {
            if (await updateProduct.Do(updateProductRequest) > 0)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpDelete("{productId}")]
        public async Task<IActionResult> DeleteProduct([FromServices] DeleteProduct deleteProduct, int productId)
        {
            if (await deleteProduct.Do(productId) > 0)
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}