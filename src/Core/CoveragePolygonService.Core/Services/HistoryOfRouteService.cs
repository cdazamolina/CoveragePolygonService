
using AutoMapper;
using CoveragePolygonService.Core.DTO;
using CoveragePolygonService.Core.Interfaces;

namespace CoveragePolygonService.Core.Services
{
    public class HistoryOfRouteService : IHistoryOfRouteService
    {
        private readonly IAsyncRepository<Entities.HistoryOfRoute> _repository;
        private readonly IMapper _mapper;

        public HistoryOfRouteService(IAsyncRepository<Entities.HistoryOfRoute> repository, IMapper mapper)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<HistoryOfRoute> CreateHistoryOfRouteAsync(HistoryOfRoute historyOfRoute)
        {
            Entities.HistoryOfRoute newHistoryOfRoute = _mapper.Map<Entities.HistoryOfRoute>(historyOfRoute);
            newHistoryOfRoute = await _repository.CreateAsync(newHistoryOfRoute);
            historyOfRoute.Id = newHistoryOfRoute.Id;
            return historyOfRoute;
        }
    }
}
