using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Category;
using Shop.Application.Category.Requests;

namespace WebApplication.Controllers
{
    [Route("/api/[controller]")]
    public class CategoryController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromServices] CreateCategory createCategory, [FromBody] CreateCategoryRequest request)
        {
            if (await createCategory.Do(request) > 0)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpGet("list")]
        public IActionResult List([FromServices] ListCategories listCategories)
        {
            return Json(listCategories.Do());
        }

        [HttpGet("{categoryId}")]
        public IActionResult GetCategory([FromServices] GetCategory getCategory, int categoryId)
        {
            return Json(getCategory.Do(categoryId));
        }

        [HttpDelete("{categoryId}")]
        public async Task<IActionResult> DeleteCategory([FromServices] DeleteCategory deleteCategory, int categoryId)
        {
            bool success = await deleteCategory.Do(categoryId) > 0;

            if (success)
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}