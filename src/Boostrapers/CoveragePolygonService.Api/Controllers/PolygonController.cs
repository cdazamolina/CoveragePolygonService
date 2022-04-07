using Microsoft.AspNetCore.Mvc;

namespace CoveragePolygonService.Api.Controllers
{

    public class PolygonController : ApiControllerBase
    {
        private readonly ILogger<PolygonController> _logger;

        public PolygonController(ILogger<PolygonController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetPolygon")]
        public IEnumerable<Object> Get() => new List<Object>();
    }
}