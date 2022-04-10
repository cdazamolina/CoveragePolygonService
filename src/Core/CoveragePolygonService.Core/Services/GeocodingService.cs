using AutoMapper;
using CoveragePolygonService.Core.DTO;
using CoveragePolygonService.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoveragePolygonService.Core.Services
{
    public class GeocodingService : IGeocodingService
    {
        private readonly IRouteCoverageService _routeCoverageService;
        private readonly IGeocode _geocode;

        public GeocodingService(IRouteCoverageService routeCoverageService, IGeocode geocode)
        {
            _routeCoverageService = routeCoverageService ?? throw new ArgumentNullException(nameof(routeCoverageService));
            _geocode = geocode ?? throw new ArgumentNullException(nameof(geocode));
        }

        public async Task<RouteCoverage> GetRouteCoverageByAddress(string address)
        {
            IEnumerable<RouteCoverage> routeCoverages = await _routeCoverageService.GetRouteCoveragesAsync();
            return await _geocode.GetRouteByAddress(routeCoverages, address);
        }
    }
}
