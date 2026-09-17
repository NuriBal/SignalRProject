using AutoMapper;
using SignalR.Dto.ProductDto;
using SignalR.Entity.Entities;

namespace SignalR.API.Mapping;

public class ProductMapping : Profile
{
    protected ProductMapping()
    {
        CreateMap<Product, ResultProductDto>();
        CreateMap<Product, GetProductDto>();
        CreateMap<CreateProductDto, Product>();
        CreateMap<UpdateProductDto, Product>().ReverseMap();
    }
}
