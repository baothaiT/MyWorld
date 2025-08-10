using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MyWorld.MasterDataAPI.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetHealthStatus()
        {
            // This is a simple health check endpoint
            return Ok(new { Status = "Healthy", Timestamp = DateTime.UtcNow });
        }
    }
}
