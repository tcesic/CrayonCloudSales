using CCPService.Models;
using Microsoft.AspNetCore.Mvc;

namespace CCPService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private static List<Service> services = new List<Service>
        {
            new Service { Id = 1, Name = "Microsoft Office", Description = "Office suite", Price = 100 },
            new Service { Id = 2, Name = "Adobe Photoshop", Description = "Photo editing software", Price = 150 },
            new Service { Id = 3, Name = "AWS Cloud", Description = "Cloud computing services", Price = 200 }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Service>> GetAvailableServices()
        {
            return Ok(services);
        }

        [HttpPost("order")]
        public ActionResult<Service> OrderService([FromBody] OrderRequest request)
        {
            var service = services.Find(s => s.Id == request.ServiceId);

            if (service == null)
            {
                return NotFound();
            }

            // Mocking an order service call
            return Ok(service);
        }
    }
}
