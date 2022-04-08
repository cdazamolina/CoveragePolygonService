using AutoMapper;
using CoveragePolygonService;
using CoveragePolygonService.Infraestructure.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CoveragePolygonService.Api.Controllers
{

    public class PolygonController : ApiControllerBase
    {
        private readonly CoveragePolygonContext _dbContext;
        private readonly IMapper _mapper;

        public PolygonController(CoveragePolygonContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IEnumerable<Core.Entities.RouteCoverage> routesCoverageEntities = await _dbContext.RouteCoverages
                .Include(x => x.Positions)
                .ToListAsync();

            IEnumerable<Core.DTO.RouteCoverage> routesCoverageDTO = _mapper
                .Map<IEnumerable<Core.DTO.RouteCoverage>>(routesCoverageEntities);

            return Ok(routesCoverageDTO);
        }

        [HttpGet("{id}")]
        public IActionResult Get([FromRoute] long id)
        {
            Core.Entities.RouteCoverage routeCoverageEntity = _dbContext.RouteCoverages
                .Include(x => x.Positions)
                .FirstOrDefault(x => x.Id == id);

            if (routeCoverageEntity is null) return NotFound($"Route Coverage with Id {id} does not found!");

            Core.DTO.RouteCoverage routeCoverageDTO = _mapper.Map<Core.DTO.RouteCoverage>(routeCoverageEntity);
            return Ok(routeCoverageDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Core.DTO.RouteCoverage routeCoverageDTO)
        {
            if (ModelState.IsValid)
            {
                Core.Entities.RouteCoverage routeCoverageEntity = _mapper
                    .Map<Core.Entities.RouteCoverage>(routeCoverageDTO);
                
                _dbContext.RouteCoverages.Add(routeCoverageEntity);
                 await _dbContext.SaveChangesAsync();

                return Ok();
            }
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] long id, Core.DTO.RouteCoverage routeCoverageDTO)
        {
            if (ModelState.IsValid)
            {

                Core.Entities.RouteCoverage currentRouteCoverageEntity = _dbContext.RouteCoverages
                    .Include(x => x.Positions)
                    .FirstOrDefault(x => x.Id == id);

                if (currentRouteCoverageEntity is null)
                    return NotFound($"Route Coverage with Id {id} does not found!");
                
                Core.Entities.RouteCoverage routeCoverageEntity = _mapper
                    .Map<Core.Entities.RouteCoverage>(routeCoverageDTO);

                currentRouteCoverageEntity.Name = routeCoverageEntity.Name;
                currentRouteCoverageEntity.Description = routeCoverageEntity.Description;
                currentRouteCoverageEntity.Positions = routeCoverageEntity.Positions;

                _dbContext.RouteCoverages.Update(currentRouteCoverageEntity);
                await _dbContext.SaveChangesAsync();
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] long id)
        {
            Core.Entities.RouteCoverage routeCoverageEntity = _dbContext.RouteCoverages
                .Include(x => x.Positions)
                .FirstOrDefault(x => x.Id == id);

            if (routeCoverageEntity is null) return NotFound($"Route Coverage with Id {id} does not found!");

            _dbContext.RouteCoverages.Remove(routeCoverageEntity);
            await _dbContext.SaveChangesAsync();
            return Ok();
        }
    }
}