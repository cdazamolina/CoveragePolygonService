using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CoveragePolygonService.Core.DTO;
using CoveragePolygonService.Core.Exceptions;
using CoveragePolygonService.Core.Interfaces;

namespace CoveragePolygonService.Core.Services
{
    public class RouteCoverageService : IRouteCoverageService
    {
        private readonly IAsyncRepository<Entities.RouteCoverage> _repository;
        private readonly IMapper _mapper;

        public RouteCoverageService(IAsyncRepository<Entities.RouteCoverage> repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<RouteCoverage> CreateRouteCoverageAsync(RouteCoverage routeCoverage)
        {
            Entities.RouteCoverage newRouteCoverage = _mapper.Map<Entities.RouteCoverage>(routeCoverage);
            newRouteCoverage = await _repository.CreateAsync(newRouteCoverage);
            routeCoverage.Id = newRouteCoverage.Id;
            return routeCoverage;
        }

        public async Task DeleteRouteCoverageAsync(long id)
        {
            Entities.RouteCoverage routeCoverage = await _repository.GetByIdAsync(id);
            if(routeCoverage is null) 
                throw new RouteCoverageDoesNotFoundException($"Route coverage with id [{id}] does not exist!");

            await _repository.DeleteAsync(routeCoverage);
        }

        public async Task<RouteCoverage> GetRouteCoverageAsync(long id)
        {
            Entities.RouteCoverage routeCoverage = await _repository.GetByIdAsync(id);
            if (routeCoverage is null)
                throw new RouteCoverageDoesNotFoundException($"Route coverage with id [{id}] does not exist!");

            return _mapper.Map<RouteCoverage>(routeCoverage);
        }

        public async Task<IEnumerable<RouteCoverage>> GetRouteCoveragesAsync()
        {
            IEnumerable<Entities.RouteCoverage> routeCoverages = await _repository.GetAllAsync();
            return _mapper.Map<List<RouteCoverage>>(routeCoverages);
        }

        public async Task<RouteCoverage> UpdateRouteCoverageAsync(long id, RouteCoverage routeCoverage)
        {
            Entities.RouteCoverage routeCoverageToUpdate = await _repository.GetByIdAsync(id);
            if (routeCoverage is null)
                throw new RouteCoverageDoesNotFoundException($"Route coverage with id [{id}] does not exist!");

            routeCoverageToUpdate.Name = routeCoverage.Name;
            routeCoverageToUpdate.Description = routeCoverage.Description;
            routeCoverageToUpdate.Positions = _mapper.Map<List<Entities.Geoposition>>(routeCoverage.Positions);
            throw new NotImplementedException();
        }
    }
}
