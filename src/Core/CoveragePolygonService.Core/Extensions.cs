using AutoMapper;
using CoveragePolygonService.Core.Interfaces;
using CoveragePolygonService.Core.Mappers;
using CoveragePolygonService.Core.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace CoveragePolygonService.Core
{
    public static class Extensions
    {
        private static readonly string _seqSectionPath = "SeqService";

        public static IServiceCollection AddCoreServices(this IServiceCollection services)
        {
            services.AddScoped<IRouteCoverageService, RouteCoverageService>();
            services.AddScoped<IHistoryOfRouteService, HistoryOfRouteService>();

            IConfiguration configuration = services.BuildServiceProvider().GetRequiredService<IConfiguration>();
            services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.AddSeq(configuration.GetSection(_seqSectionPath));
            });

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new RouteCoverageMappingProfile());
                mc.AddProfile(new GeopositionMappingProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            services.AddSingleton(mapper);

            services.AddScoped<IGeocodingService, GeocodingService>();
            return services;
        }
    }
}
