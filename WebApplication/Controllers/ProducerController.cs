using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.Application.Producer;
using Shop.Application.Producer.Requests;

namespace WebApplication.Controllers
{
    [Route("/api/[controller]")]
    public class ProducerController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> CreateProducer([FromServices] CreateProducer createProducer, [FromBody] CreateProducerRequest request)
        {
            if (await createProducer.Do(request) > 0)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpGet("list")]
        public IActionResult ListProducers([FromServices] ListProducers listProducers)
        {
            return Json(listProducers.Do());
        }
    }
}