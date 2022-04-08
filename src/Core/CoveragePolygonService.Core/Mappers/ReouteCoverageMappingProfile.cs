using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoveragePolygonService.Core.Mappers
{
    public class RouteCoverageMappingProfile : Profile
    {
        public RouteCoverageMappingProfile()
        {
            CreateMap<DTO.RouteCoverage, Entities.RouteCoverage>();
            CreateMap<Entities.RouteCoverage, DTO.RouteCoverage>();
        }
    }
}
