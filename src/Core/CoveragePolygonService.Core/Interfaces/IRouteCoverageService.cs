using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoveragePolygonService.Core.Interfaces
{
    public interface IRouteCoverageService
    {
        public Task<IEnumerable<DTO.RouteCoverage>> GetRouteCoveragesAsync();
        public Task<DTO.RouteCoverage> GetRouteCoverageAsync(long id);
        public Task<DTO.RouteCoverage> CreateRouteCoverageAsync(DTO.RouteCoverage routeCoverage);
        public Task<DTO.RouteCoverage> UpdateRouteCoverageAsync(long id, DTO.RouteCoverage routeCoverage);
        public Task DeleteRouteCoverageAsync(long id);
    }
}
