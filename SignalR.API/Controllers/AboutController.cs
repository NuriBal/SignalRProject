using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.Bussiness.Abstract;
using SignalR.Dto.AboutDto;
using SignalR.Entity.Entities;

namespace SignalR.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AboutController : ControllerBase
{
    private readonly IAboutService _service;
    private readonly IMapper _mapper;

    public AboutController(IAboutService aboutService, IMapper mapper)
    {
        _service = aboutService;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult List()
    {
        var values = _service.TGetListAll();
        var response = _mapper.Map<List<ResultAboutDto>>(values);
        return Ok(response);
    }

    [HttpGet("GetAbout")]
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
    public IActionResult HardDelete(string id)
    {
        var value = _service.TGetById(id);
        _service.TDelete(value);
        return Ok("Hakkımda bilgisi tamamen silindi");
    }
}
