using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.Bussiness.Abstract;
using SignalR.Dto.BookingDto;
using SignalR.Entity.Entities;

namespace SignalR.API.Controllers
{
    [Route("api/bookings")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IBookingService _service;
        private readonly IMapper _mapper;

        public BookingController(IBookingService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult List()
        {
            var values = _service.TGetListAll();
            var response = _mapper.Map<List<ResultBookingDto>>(values);
            return Ok(response);
        }

        [HttpGet("getById")]
        public IActionResult GetBooking(string id)
        {
            var value = _service.TGetById(id);
            var response = _mapper.Map<GetBookingDto>(value);
            return Ok(response);
        }

        [HttpPost]
        public IActionResult Create(CreateBookingDto dto)
        {
            var entity = _mapper.Map<Booking>(dto);
            _service.TAdd(entity);
            return Ok("Rezervasyon bilgisi başarı ile eklendi");
        }

        [HttpPut]
        public IActionResult Update(UpdateBookingDto dto)
        {
            var entity = _mapper.Map<Booking>(dto);
            _service.TUpdate(entity);
            return Ok("Rezervasyon bilgisi başarı ile güncellendi");
        }

        [HttpDelete]
        public IActionResult Delete(string id)
        {
            var entity = _service.TGetById(id);
            entity.UpdatedDate = DateTime.Now;
            entity.IsActive = false;
            _service.TUpdate(entity);
            return Ok("Rezervasyon bilgisi silindi");
        }

        //[HttpDelete]
        //public IActionResult HardDelete(string id)
        //{
        //    var value = _service.TGetById(id);
        //    _service.TDelete(value);
        //    return Ok("Rezervasyon bilgisi tamamen silindi");
        //}
    }
}
