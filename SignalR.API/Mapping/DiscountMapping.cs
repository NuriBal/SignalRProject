using AutoMapper;
using SignalR.Dto.DiscountDto;
using SignalR.Entity.Entities;

namespace SignalR.API.Mapping;

public class DiscountMapping : Profile
{
    public DiscountMapping()
    {
        CreateMap<Discount, ResultDiscountDto>();
        CreateMap<Discount, GetDiscountDto>();
        CreateMap<CreateDiscountDto, Discount>();
        CreateMap<UpdateDiscountDto, Discount>().ReverseMap();
    }
}
