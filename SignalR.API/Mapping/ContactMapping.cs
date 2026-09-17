using AutoMapper;
using SignalR.Dto.ContactDto;
using SignalR.Entity.Entities;

namespace SignalR.API.Mapping;

public class ContactMapping : Profile
{
    protected ContactMapping()
    {
        CreateMap<Contact, ResultContactDto>();
        CreateMap<Contact, GetContactDto>();
        CreateMap<CreateContactDto, Contact>();
        CreateMap<UpdateContactDto, Contact>().ReverseMap();
    }
}
