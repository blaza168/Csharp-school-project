using System;
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

        [HttpGet("{producerId}")]
        public IActionResult GetProducer([FromServices] GetProducer getProducer, int producerId)
        {
            return Json(getProducer.Do(producerId));
        }

        [HttpDelete("{producerId}")]
        public async Task<IActionResult> DeleteProducer([FromServices] DeleteProducer deleteProducer, int producerId)
        {
            bool success = await deleteProducer.Do(producerId) > 0;
            
            if (success)
            {
                return Ok();
            }

            return BadRequest();
        }
        
        /// <summary>
        /// Endpoint for partial producer update
        /// </summary>
        /// <param name="updateProducer"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> UpdateProducer([FromServices] UpdateProducer updateProducer, [FromBody] UpdateProducerRequest request)
        {
            bool success = await updateProducer.Do(request) > 0;
            
            if (success)
            {
                return Ok();
            }

            return BadRequest();
        }
    }
}