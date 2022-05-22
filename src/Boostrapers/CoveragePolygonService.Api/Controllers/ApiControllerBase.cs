using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace CoveragePolygonService.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ApiControllerBase : ControllerBase
    {
        [HttpGet("/")]
        public IActionResult Health() => Ok();
    }
}