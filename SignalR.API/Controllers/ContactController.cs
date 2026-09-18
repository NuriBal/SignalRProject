using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.Bussiness.Abstract;
using SignalR.Dto.ContactDto;
using SignalR.Entity.Entities;

namespace SignalR.API.Controllers
{
    [Route("api/contacts")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _service;
        private readonly IMapper _mapper;

        public ContactController(IContactService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult List()
        {
            var values = _service.TGetListAll();
            var response = _mapper.Map<List<ResultContactDto>>(values);
            return Ok(response);
        }

        [HttpGet("getById")]
        public IActionResult GetContact(string id)
        {
            var value = _service.TGetById(id);
            var response = _mapper.Map<GetContactDto>(value);
            return Ok(response);
        }

        [HttpPost]
        public IActionResult Create(CreateContactDto dto)
        {
            var entity = _mapper.Map<Contact>(dto);
            _service.TAdd(entity);
            return Ok("İletişim bilgisi başarı ile eklendi");
        }

        [HttpPut]
        public IActionResult Update(UpdateContactDto dto)
        {
            var entity = _mapper.Map<Contact>(dto);
            _service.TUpdate(entity);
            return Ok("İletişim bilgisi başarı ile güncellendi");
        }

        [HttpDelete]
        public IActionResult Delete(string id)
        {
            var entity = _service.TGetById(id);
            entity.UpdatedDate = DateTime.Now;
            entity.IsActive = false;
            _service.TUpdate(entity);
            return Ok("İletişim bilgisi silindi");
        }

        //[HttpDelete]
        //public IActionResult HardDelete(string id)
        //{
        //    var value = _service.TGetById(id);
        //    _service.TDelete(value);
        //    return Ok("İletişim bilgisi tamamen silindi");
        //}
    }
}
