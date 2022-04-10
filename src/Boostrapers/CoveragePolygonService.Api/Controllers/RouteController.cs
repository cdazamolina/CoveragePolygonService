using CoveragePolygonService.Core.DTO;
using CoveragePolygonService.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoveragePolygonService.Api.Controllers
{
    public class RouteController : ApiControllerBase
    {
        private readonly IGeocodingService _geocodingService;
        private readonly ILogger<RouteController> _logger;

        public RouteController(IGeocodingService geocodingService, ILogger<RouteController> logger)
        {
            _geocodingService = geocodingService ?? throw new ArgumentNullException(nameof(geocodingService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericApiResult), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<RouteCoverage>> Get(string address)
        {
            _logger.LogInformation($"Searching route for address [{address}].");
            var routeCoverage = await _geocodingService.GetRouteCoverageByAddress(address);
            if (routeCoverage is null)
            {
                var error = new GenericApiResult($"No route suggested for addres: {address}.");
                _logger.LogError(error.Message);
                return NotFound(error);
            }
            else
            {
                return Ok(routeCoverage);
            }
        }
    }
}
