using CoveragePolygonService.Infraestructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CoveragePolygonService.Infraestructure
{
    public static class Extensions
    {
        private static readonly string CoveragePolygonConnectionString = "CoveragePolygon";
        public static IServiceCollection AddInfraestructureServices(this IServiceCollection services)
        {
            IConfiguration configuration = services.BuildServiceProvider().GetRequiredService<IConfiguration>();

            services.AddDbContext<CoveragePolygonContext>(options => 
                options.UseSqlServer(configuration.GetConnectionString(CoveragePolygonConnectionString)));

            return services;
        }
    }
}
