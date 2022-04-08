using AutoMapper;
using CoveragePolygonService.Core.Mappers;
using Microsoft.Extensions.DependencyInjection;

namespace CoveragePolygonService.Core
{
    public static class Extensions
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection services)
        {
            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new RouteCoverageMappingProfile());
                mc.AddProfile(new GeopositionMappingProfile());
            });

            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);
            return services;
        }
    }
}
