using Microsoft.EntityFrameworkCore;
using System.Reflection;
using CoveragePolygonService.Core.Entities;

namespace CoveragePolygonService.Infraestructure.Contexts
{
    public class CoveragePolygonContext : DbContext
    {
        public DbSet<RouteCoverage> RouteCoverages { get; set; }
        public DbSet<Geoposition> Geopositions { get; set; }
        public DbSet<HistoryOfRoute> HistoryOfRoutes { get; set; }

        public CoveragePolygonContext(DbContextOptions<CoveragePolygonContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            modelBuilder.FillStartingRoutes();
        }
    }
}
