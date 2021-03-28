using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Rating;
using Shop.Application.Rating.Requests;

namespace WebApplication.Controllers
{
    [Route("/api/[controller]")]
    public class RatingController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> CreateRating([FromServices] CreateRating createRating, [FromBody] CreateRatingRequest request)
        {
            if (await createRating.Do(request) > 0)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpGet("list")]
        public IActionResult ListRatings([FromServices] ListRatings listRatings)
        {
            return Json(listRatings.Do());
        }
    }
}