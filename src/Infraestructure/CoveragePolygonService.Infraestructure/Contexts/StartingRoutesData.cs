using Microsoft.EntityFrameworkCore;
using CoveragePolygonService.Core.Entities;
using System.Text.Json;

namespace CoveragePolygonService.Infraestructure.Contexts
{
    internal static class StartingRoutesData
    {
        private const string _startingRoutes = "StartingRoutes.json";
        internal static ModelBuilder FillStartingRoutes(this ModelBuilder modelBuilder)
        {
            string filepath = Path.Combine(Directory.GetCurrentDirectory(), _startingRoutes);
            if (File.Exists(filepath))
            {
                try
                {
                    string fileContent = File.ReadAllText(filepath);
                    IEnumerable<RouteCoverage> routeCoverages = JsonSerializer
                        .Deserialize<IEnumerable<RouteCoverage>>(fileContent);

                    foreach (RouteCoverage routeCoverage in routeCoverages)
                        modelBuilder.Entity<RouteCoverage>().HasData(routeCoverage);
                }
                catch (Exception)
                {

                }
            }
            return modelBuilder;
        }
    }
}
