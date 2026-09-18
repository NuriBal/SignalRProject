using AutoMapper;
using SignalR.Dto.FeatureDto;
using SignalR.Entity.Entities;

namespace SignalR.API.Mapping;

public class FeatureMapping : Profile
{
    public FeatureMapping()
    {
        CreateMap<Feature, ResultFeatureDto>();
        CreateMap<Feature, GetFeatureDto>();
        CreateMap<CreateFeatureDto, Feature>();
        CreateMap<UpdateFeatureDto, Feature>().ReverseMap();
    }
}
