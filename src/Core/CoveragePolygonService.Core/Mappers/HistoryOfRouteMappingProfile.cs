using AutoMapper;

namespace CoveragePolygonService.Core.Mappers
{
    public class HistoryOfRouteMappingProfile : Profile
    {
        public HistoryOfRouteMappingProfile()
        {
            CreateMap<DTO.HistoryOfRoute, Entities.HistoryOfRoute>();
            CreateMap<Entities.HistoryOfRoute, DTO.HistoryOfRoute>();
        }
    }
}
