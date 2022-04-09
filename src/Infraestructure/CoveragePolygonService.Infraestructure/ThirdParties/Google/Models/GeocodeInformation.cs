using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoveragePolygonService.Infraestructure.ThirdParties.Google.Models
{
    public class GeocodeInformation
    {
        public Result[] results { get; set; }
        public string status { get; set; }
    }
}
