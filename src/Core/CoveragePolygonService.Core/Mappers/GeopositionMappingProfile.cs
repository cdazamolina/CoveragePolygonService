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
}
