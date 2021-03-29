using Microsoft.AspNetCore.Mvc;
using Shop.Application.Search;

namespace WebApplication.Controllers
{
    [Route("/api/[controller]")]
    public class SearchController : Controller
    {
        [HttpGet("search")]
        public IActionResult FullTextSearch([FromServices] FullTextSearchService fullTextSearchService, string text)
        {
            return Json(fullTextSearchService.Do(text));
        }
    }
}