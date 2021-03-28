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

        [HttpGet("{ratingId}")]
        public IActionResult GetRating([FromServices] GetRating getRating, int ratingId)
        {
            return Json(getRating.Do(ratingId));
        }

        [HttpGet("ForProduct/{productId}")]
        public IActionResult GetRatingsForProduct([FromServices] GetRatingsForProduct getRatingsForProduct, int productId)
        {
            return Json(getRatingsForProduct.Do(productId));
        }

        [HttpDelete("{ratingId}")]
        public async Task<IActionResult> DeleteRating([FromServices] DeleteRating deleteRating, int ratingId)
        {
            bool success = await deleteRating.Do(ratingId) > 0;

            if (success)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRating([FromServices] UpdateRating updateRating, [FromBody] UpdateRatingRequest request)
        {
            bool success = await updateRating.Do(request) > 0;

            if (success)
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}