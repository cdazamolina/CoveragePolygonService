namespace CoveragePolygonService.Core.Interfaces
{
    public interface IHistoryOfRouteService
    {
        public Task<DTO.HistoryOfRoute> CreateHistoryOfRouteAsync(DTO.HistoryOfRoute historyOfRoute);
    }
}
