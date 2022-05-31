using AutoMapper;

namespace CoveragePolygonService.Core.Mappers
{
    public class GeopositionMappingProfile : Profile
    {
        public GeopositionMappingProfile()
        {
            CreateMap<DTO.Geoposition, Entities.Geoposition>();
            CreateMap<Entities.Geoposition, DTO.Geoposition>();
        }
    }
    public class HistoryOfRouteMappingProfile : Profile
    {
        public HistoryOfRouteMappingProfile()
        {
            CreateMap<DTO.HistoryOfRoute, Entities.HistoryOfRoute>();
            CreateMap<Entities.HistoryOfRoute, DTO.HistoryOfRoute>();
        }
    }
}
