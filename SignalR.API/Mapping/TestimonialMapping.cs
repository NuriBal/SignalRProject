using AutoMapper;
using SignalR.Dto.TestimonialDto;
using SignalR.Entity.Entities;

namespace SignalR.API.Mapping;

public class TestimonialMapping : Profile
{
    protected TestimonialMapping()
    {
        CreateMap<Testimonial, ResultTestimonialDto>();
        CreateMap<Testimonial, GetTestimonialDto>();
        CreateMap<CreateTestimonialDto, Testimonial>();
        CreateMap<UpdateTestimonialDto, Testimonial>().ReverseMap();
    }
}
