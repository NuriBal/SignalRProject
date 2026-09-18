using AutoMapper;
using SignalR.Dto.AboutDto;
using SignalR.Entity.Entities;

namespace SignalR.API.Mapping;

public class AboutMapping : Profile
{
    public AboutMapping()
    {
        CreateMap<About, ResultAboutDto>();
        CreateMap<About, GetAboutDto>();
        CreateMap<CreateAboutDto, About>();
        CreateMap<UpdateAboutDto, About>().ReverseMap();
    }
}
