using CoveragePolygonService.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoveragePolygonService.Core.Interfaces
{
    public interface IGeocodingService
    {
        public Task<RouteCoverage> GetRouteCoverageByAddress(string address);
    }
}
