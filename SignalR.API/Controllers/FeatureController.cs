using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.Bussiness.Abstract;
using SignalR.Dto.FeatureDto;
using SignalR.Entity.Entities;

namespace SignalR.API.Controllers
{
    [Route("api/features")]
    [ApiController]
    public class FeatureController : ControllerBase
    {
        private readonly IFeatureService _service;
        private readonly IMapper _mapper;

        public FeatureController(IFeatureService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult List()
        {
            var values = _service.TGetListAll();
            var response = _mapper.Map<List<ResultFeatureDto>>(values);
            return Ok(response);
        }

        [HttpGet("getById")]
        public IActionResult GetFeature(string id)
        {
            var value = _service.TGetById(id);
            var response = _mapper.Map<GetFeatureDto>(value);
            return Ok(response);
        }

        [HttpPost]
        public IActionResult Create(CreateFeatureDto dto)
        {
            var entity = _mapper.Map<Feature>(dto);
            _service.TAdd(entity);
            return Ok("Özellik bilgisi başarı ile eklendi");
        }

        [HttpPut]
        public IActionResult Update(UpdateFeatureDto dto)
        {
            var entity = _mapper.Map<Feature>(dto);
            _service.TUpdate(entity);
            return Ok("Özellik bilgisi başarı ile güncellendi");
        }

        [HttpDelete]
        public IActionResult Delete(string id)
        {
            var entity = _service.TGetById(id);
            entity.UpdatedDate = DateTime.Now;
            entity.IsActive = false;
            _service.TUpdate(entity);
            return Ok("Özellik bilgisi silindi");
        }

        //[HttpDelete]
        //public IActionResult HardDelete(string id)
        //{
        //    var value = _service.TGetById(id);
        //    _service.TDelete(value);
        //    return Ok("Özellik bilgisi tamamen silindi");
        //}
    }
}
