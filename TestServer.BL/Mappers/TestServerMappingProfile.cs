using AutoMapper;
using TestServer.BL.Dtos;
using TestServer.DM.Entities;

namespace TestServer.BL.Mappers
{
    public class TestServerMappingProfile : Profile
    {
        public TestServerMappingProfile()
        {
            CreateMap<PermitType, PermitTypeDto>()
            .ReverseMap();

            CreateMap<Permit, PermitDto>()
            .ReverseMap()
            .ForMember(dto => dto.CreatedAt, cfg => cfg.Ignore());
        }
    }
}
