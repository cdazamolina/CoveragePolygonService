﻿using CoveragePolygonService.Core.Interfaces;
using CoveragePolygonService.Core.DTO;
using Microsoft.AspNetCore.Mvc;

namespace CoveragePolygonService.Api.Controllers
{
    public class GeocodeController : ApiControllerBase
    {
        private readonly IGeocodeService _geocodeService;
        private readonly ILogger<GeocodeController> _logger;

        public GeocodeController(IGeocodeService geocodeService, ILogger<GeocodeController> logger)
        {
            _geocodeService = geocodeService ?? throw new ArgumentNullException(nameof(geocodeService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Geoposition>> Get(string address)
        {
            _logger.LogInformation($"Geocoding address [{address}].");
            return Ok(await _geocodeService.GeocodeAddressWithOutFormat(address));
        }

        [HttpGet("Route")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericApiResult), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<RouteCoverage>> GetRoute(string address)
        {
            _logger.LogInformation($"Searching route for address [{address}].");
            var routeCoverage = await _geocodeService.GetRouteCoverageToAddress(address);
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
