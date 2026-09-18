using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.Bussiness.Abstract;
using SignalR.Dto.AboutDto;
using SignalR.Entity.Entities;

namespace SignalR.API.Controllers;

[Route("api/abouts")]
[ApiController]
public class AboutController : ControllerBase
{
    private readonly IAboutService _service;
    private readonly IMapper _mapper;

    public AboutController(IAboutService service, IMapper mapper)
    {
        _service = service;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult List()
    {
        var values = _service.TGetListAll();
        var response = _mapper.Map<List<ResultAboutDto>>(values);
        return Ok(response);
    }

    [HttpGet("getById")]
    public IActionResult GetAbout(string id)
    {
        var value = _service.TGetById(id);
        var response = _mapper.Map<GetAboutDto>(value);
        return Ok(response);
    }

    [HttpPost]
    public IActionResult Create(CreateAboutDto dto)
    {
        var entity = _mapper.Map<About>(dto);
        _service.TAdd(entity);        
        return Ok("Hakkımda bilgisi başarı ile eklendi");
    }

    [HttpPut]
    public IActionResult Update(UpdateAboutDto dto)
    {
        var entity = _mapper.Map<About>(dto);
        _service.TUpdate(entity);
        return Ok("Hakkımda bilgisi başarı ile güncellendi");
    }

    [HttpDelete]
    public IActionResult Delete(string id)
    {
        var entity = _service.TGetById(id);
        entity.UpdatedDate = DateTime.Now;
        entity.IsActive = false;
        _service.TUpdate(entity);
        return Ok("Hakkımda bilgisi silindi");
    }

    //[HttpDelete]
    //public IActionResult HardDelete(string id)
    //{
    //    var value = _service.TGetById(id);
    //    _service.TDelete(value);
    //    return Ok("Hakkımda bilgisi tamamen silindi");
    //}
}
