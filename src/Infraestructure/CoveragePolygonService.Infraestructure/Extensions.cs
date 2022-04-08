using CoveragePolygonService.Infraestructure.Contexts;
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

            services.AddDbContext<CoveragePolygonContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString(_coveragePolygonConnectionString)));

            return services;
        }
    }
}
