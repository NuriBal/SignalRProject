using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.Bussiness.Abstract;
using SignalR.Dto.SocialMediaDto;
using SignalR.Entity.Entities;

namespace SignalR.API.Controllers
{
    [Route("api/socialmedias")]
    [ApiController]
    public class SocialMediaController : ControllerBase
    {
        private readonly ISocialMediaService _service;
        private readonly IMapper _mapper;

        public SocialMediaController(ISocialMediaService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult List()
        {
            var values = _service.TGetListAll();
            var response = _mapper.Map<List<ResultSocialMediaDto>>(values);
            return Ok(response);
        }

        [HttpGet("getById")]
        public IActionResult GetSocialMedia(string id)
        {
            var value = _service.TGetById(id);
            var response = _mapper.Map<GetSocialMediaDto>(value);
            return Ok(response);
        }

        [HttpPost]
        public IActionResult Create(CreateSocialMediaDto dto)
        {
            var entity = _mapper.Map<SocialMedia>(dto);
            _service.TAdd(entity);
            return Ok("Sosyal medya bilgisi başarı ile eklendi");
        }

        [HttpPut]
        public IActionResult Update(UpdateSocialMediaDto dto)
        {
            var entity = _mapper.Map<SocialMedia>(dto);
            _service.TUpdate(entity);
            return Ok("Sosyal medya bilgisi başarı ile güncellendi");
        }

        [HttpDelete]
        public IActionResult Delete(string id)
        {
            var entity = _service.TGetById(id);
            entity.UpdatedDate = DateTime.Now;
            entity.IsActive = false;
            _service.TUpdate(entity);
            return Ok("Sosyal medya bilgisi silindi");
        }

        //[HttpDelete]
        //public IActionResult HardDelete(string id)
        //{
        //    var value = _service.TGetById(id);
        //    _service.TDelete(value);
        //    return Ok("Sosyal medya bilgisi tamamen silindi");
        //}
    }
}
