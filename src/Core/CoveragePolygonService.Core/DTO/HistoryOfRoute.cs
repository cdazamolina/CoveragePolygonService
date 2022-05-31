using System.ComponentModel.DataAnnotations;

namespace CoveragePolygonService.Core.DTO
{
    public class HistoryOfRoute
    {
        [Key]
        public long Id { get; set; }

        [Required]
        public bool RouteFound { get; set; }

        [Required]
        public string Address { get; set; }

        public string RouteName { get; set; }
    }
}
