using AutoMapper;
using SignalR.Dto.ProductDto;
using SignalR.Entity.Entities;

namespace SignalR.API.Mapping;

public class ProductMapping : Profile
{
    public ProductMapping()
    {
        CreateMap<Product, ResultProductDto>().ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category != null ? src.Category.Name : null));
        CreateMap<Product, GetProductDto>().ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category != null ? src.Category.Name : null));
        CreateMap<CreateProductDto, Product>();
        CreateMap<UpdateProductDto, Product>().ReverseMap();
    }
}
