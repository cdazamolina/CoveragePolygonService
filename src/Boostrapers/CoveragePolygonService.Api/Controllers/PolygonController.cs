using AutoMapper;
using CoveragePolygonService;
using CoveragePolygonService.Core.DTO;
using CoveragePolygonService.Core.Exceptions;
using CoveragePolygonService.Core.Interfaces;
using CoveragePolygonService.Infraestructure.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using System;
using System.Net;

namespace CoveragePolygonService.Api.Controllers
{

    public class PolygonController : ApiControllerBase
    {
        private readonly IRouteCoverageService _routeCoverageService;
        private readonly ILogger<PolygonController> _logger;

        public PolygonController(IRouteCoverageService routeCoverageService, ILogger<PolygonController> logger)
        {
            _routeCoverageService = routeCoverageService ?? throw new ArgumentNullException(nameof(routeCoverageService));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<List<RouteCoverage>>> Get()
        {
            _logger.LogInformation($"Listing all route coverages.");
            return Ok(await _routeCoverageService.GetRouteCoveragesAsync());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericApiResult), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<RouteCoverage>> Get([FromRoute] long id)
        {
            try
            {
                _logger.LogInformation($"List route coverage with id [{id}].");
                RouteCoverage routeCoverage = await _routeCoverageService.GetRouteCoverageAsync(id);
                return Ok(routeCoverage);
            }
            catch (RouteCoverageDoesNotFoundException exception)
            {
                _logger.LogError(exception.Message);
                return NotFound(new GenericApiResult(exception.Message));
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericApiResult), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<RouteCoverage>> Post(RouteCoverage routeCoverage)
        {
            if (!ModelState.IsValid)
            {
                string errorMessage = "Model is not valid!";
                _logger.LogError(errorMessage);
                return BadRequest(new GenericApiResult(errorMessage));
            }

            _logger.LogInformation($"Creating new route coverage [{routeCoverage.Name}].");
            return Ok(await _routeCoverageService.CreateRouteCoverageAsync(routeCoverage));
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericApiResult), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(GenericApiResult), StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<RouteCoverage>> Update([FromRoute] long id, RouteCoverage routeCoverage)
        {
            if (!ModelState.IsValid)
            {
                string errorMessage = "Model is not valid!";
                _logger.LogError(errorMessage);
                return BadRequest(new GenericApiResult(errorMessage));
            }

            try
            {
                _logger.LogInformation($"Updating route coverage [{routeCoverage.Name}] with id [{id}].");
                return Ok(await _routeCoverageService.UpdateRouteCoverageAsync(id, routeCoverage));
            }
            catch (RouteCoverageDoesNotFoundException exception)
            {
                _logger.LogError(exception.Message);
                return NotFound(new GenericApiResult(exception.Message));
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(GenericApiResult), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete([FromRoute] long id)
        {
            try
            {
                _logger.LogInformation($"Deleting route coverage with id [{id}].");
                await _routeCoverageService.DeleteRouteCoverageAsync(id);
                return Ok();
            }
            catch (RouteCoverageDoesNotFoundException exception)
            {
                _logger.LogError(exception.Message);
                return NotFound(new GenericApiResult(exception.Message));
            }
        }
    }
}