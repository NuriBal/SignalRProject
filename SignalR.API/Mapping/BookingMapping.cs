using AutoMapper;
using SignalR.Dto.BookingDto;
using SignalR.Entity.Entities;

namespace SignalR.API.Mapping;

public class BookingMapping : Profile
{
    protected BookingMapping()
    {
        CreateMap<Booking, ResultBookingDto>();
        CreateMap<Booking, GetBookingDto>();
        CreateMap<CreateBookingDto, Booking>();
        CreateMap<UpdateBookingDto, Booking>().ReverseMap();
    }
}
