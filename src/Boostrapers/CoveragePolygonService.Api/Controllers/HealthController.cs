using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoveragePolygonService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HealthController : ControllerBase
    {
        [HttpGet("/")]
        public IActionResult Health() => Ok();
    }
}
