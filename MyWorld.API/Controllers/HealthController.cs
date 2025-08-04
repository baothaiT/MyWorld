using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyWorld.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            // This endpoint is used to check the health of the service.
            // It returns a 200 OK response if the service is healthy.
            return Ok(new { Status = "Healthy", ServiceName = "MyWorldAPI" });
        }
    }
}
