﻿using CoveragePolygonService.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoveragePolygonService.Core.Interfaces
{
    public interface IGeocode
    {
        public Task<RouteCoverage> GetRouteByAddress(IEnumerable<RouteCoverage> routeCoverages, string address);
    }
}
