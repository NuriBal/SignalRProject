using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.Bussiness.Abstract;
using SignalR.Dto.TestimonialDto;
using SignalR.Entity.Entities;

namespace SignalR.API.Controllers
{
    [Route("api/testimonials")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _service;
        private readonly IMapper _mapper;

        public TestimonialController(ITestimonialService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult List()
        {
            var values = _service.TGetListAll();
            var response = _mapper.Map<List<ResultTestimonialDto>>(values);
            return Ok(response);
        }

        [HttpGet("getById")]
        public IActionResult GetTestimonial(string id)
        {
            var value = _service.TGetById(id);
            var response = _mapper.Map<GetTestimonialDto>(value);
            return Ok(response);
        }

        [HttpPost]
        public IActionResult Create(CreateTestimonialDto dto)
        {
            var entity = _mapper.Map<Testimonial>(dto);
            _service.TAdd(entity);
            return Ok("Yorum bilgisi başarı ile eklendi");
        }

        [HttpPut]
        public IActionResult Update(UpdateTestimonialDto dto)
        {
            var entity = _mapper.Map<Testimonial>(dto);
            _service.TUpdate(entity);
            return Ok("Yorum bilgisi başarı ile güncellendi");
        }

        [HttpDelete]
        public IActionResult Delete(string id)
        {
            var entity = _service.TGetById(id);
            entity.UpdatedDate = DateTime.Now;
            entity.IsActive = false;
            _service.TUpdate(entity);
            return Ok("Yorum bilgisi silindi");
        }

        //[HttpDelete]
        //public IActionResult HardDelete(string id)
        //{
        //    var value = _service.TGetById(id);
        //    _service.TDelete(value);
        //    return Ok("Yorum bilgisi tamamen silindi");
        //}
    }
}
