using System.ComponentModel.DataAnnotations;

namespace CoveragePolygonService.Core.DTO
{
    public class GeocodeInformation
    {
        [Required]
        public string Status { get; set; }
        public Geoposition Geoposition { get; set; }
    }
}
