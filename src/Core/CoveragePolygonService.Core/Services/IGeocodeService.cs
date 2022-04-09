using CoveragePolygonService.Core.DTO;
using CoveragePolygonService.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoveragePolygonService.Core.Services
{
    public class GeocodeService : IGeocodeService
    {
        private readonly IRouteCoverageService _routeCoverageService;
        private readonly IGeocode _geocode;

        public GeocodeService(IRouteCoverageService routeCoverageService, IGeocode geocode)
        {
            _routeCoverageService = routeCoverageService ?? throw new ArgumentNullException(nameof(routeCoverageService));
            _geocode = geocode ?? throw new ArgumentNullException(nameof(geocode));
        }

        public Task<GeocodeInformation> GeocodeAddressWithOutFormat(string address) =>
            _geocode.GeocodeAddressWithOutFormat(address);

        public async Task<RouteCoverage> GetRouteCoverageToAddress(string address)
        {
            var geocode = await _geocode.GeocodeAddressWithOutFormat(address);
            if (geocode.Status != "OK")
            {
                return null;
            }

            var routeCoverages = await _routeCoverageService.GetRouteCoveragesAsync();
            foreach (RouteCoverage routeCoverage in routeCoverages)
                if (_geocode.IsPointInsidePolygon(routeCoverage.Positions, geocode.Geoposition))
                    return routeCoverage;

            return null;
        }
    }
}
