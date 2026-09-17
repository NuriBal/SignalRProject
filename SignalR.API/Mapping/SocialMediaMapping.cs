using AutoMapper;
using SignalR.Dto.SocialMediaDto;
using SignalR.Entity.Entities;

namespace SignalR.API.Mapping;

public class SocialMediaMapping : Profile
{
    protected SocialMediaMapping()
    {
        CreateMap<SocialMedia, ResultSocialMediaDto>();
        CreateMap<SocialMedia, GetSocialMediaDto>();
        CreateMap<CreateSocialMediaDto, SocialMedia>();
        CreateMap<UpdateSocialMediaDto, SocialMedia>().ReverseMap();
    }
}
