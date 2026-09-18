using AutoMapper;
using SignalR.Dto.CategoryDto;
using SignalR.Entity.Entities;

namespace SignalR.API.Mapping;

public class CategoryMapping : Profile
{
    public CategoryMapping()
    {
        CreateMap<Category, ResultCategoryDto>();
        CreateMap<Category, GetCategoryDto>();
        CreateMap<CreateCategoryDto, Category>();
        CreateMap<UpdateCategoryDto, Category>().ReverseMap();
    }
}
