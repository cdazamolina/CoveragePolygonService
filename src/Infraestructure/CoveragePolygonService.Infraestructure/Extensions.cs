using CoveragePolygonService.Core.Interfaces;
using CoveragePolygonService.Infraestructure.Contexts;
using CoveragePolygonService.Infraestructure.Repositories;
using CoveragePolygonService.Infraestructure.ThirdParties.Google;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CoveragePolygonService.Infraestructure
{
    public static class Extensions
    {
        private static readonly string _coveragePolygonConnectionString = "CoveragePolygon";
        public static IServiceCollection AddInfraestructureServices(this IServiceCollection services)
        {
            IConfiguration configuration = services.BuildServiceProvider().GetRequiredService<IConfiguration>();
            services.AddDbContext<CoveragePolygonContext>(options => options
                .UseSqlServer(configuration.GetConnectionString(_coveragePolygonConnectionString)));

            services.AddScoped<IAsyncRepository<Core.Entities.RouteCoverage>, RouteCoverageRepository>();
            services.AddScoped<IGeocode, Geocode>();
            return services;
        }
    }
}
