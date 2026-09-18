using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.Bussiness.Abstract;
using SignalR.Dto.DiscountDto;
using SignalR.Entity.Entities;

namespace SignalR.API.Controllers
{
    [Route("api/discounts")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountService _service;
        private readonly IMapper _mapper;

        public DiscountController(IDiscountService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult List()
        {
            var values = _service.TGetListAll();
            var response = _mapper.Map<List<ResultDiscountDto>>(values);
            return Ok(response);
        }

        [HttpGet("getById")]
        public IActionResult GetDiscount(string id)
        {
            var value = _service.TGetById(id);
            var response = _mapper.Map<GetDiscountDto>(value);
            return Ok(response);
        }

        [HttpPost]
        public IActionResult Create(CreateDiscountDto dto)
        {
            var entity = _mapper.Map<Discount>(dto);
            _service.TAdd(entity);
            return Ok("İndirim bilgisi başarı ile eklendi");
        }

        [HttpPut]
        public IActionResult Update(UpdateDiscountDto dto)
        {
            var entity = _mapper.Map<Discount>(dto);
            _service.TUpdate(entity);
            return Ok("İndirim bilgisi başarı ile güncellendi");
        }

        [HttpDelete]
        public IActionResult Delete(string id)
        {
            var entity = _service.TGetById(id);
            entity.UpdatedDate = DateTime.Now;
            entity.IsActive = false;
            _service.TUpdate(entity);
            return Ok("İndirim bilgisi silindi");
        }

        //[HttpDelete]
        //public IActionResult HardDelete(string id)
        //{
        //    var value = _service.TGetById(id);
        //    _service.TDelete(value);
        //    return Ok("İndirim bilgisi tamamen silindi");
        //}
    }
}
