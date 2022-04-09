using CoveragePolygonService.Core.DTO;

namespace CoveragePolygonService.Core.Interfaces
{
    public interface IGeocodeService
    {
        public Task<RouteCoverage> GetRouteCoverageToAddress(string address);
        public Task<GeocodeInformation> GeocodeAddressWithOutFormat(string address);
    }
}
