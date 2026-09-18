using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.Bussiness.Abstract;
using SignalR.Dto.CategoryDto;
using SignalR.Entity.Entities;

namespace SignalR.API.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _service;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult List()
        {
            var values = _service.TGetListAll();
            var response = _mapper.Map<List<ResultCategoryDto>>(values);
            return Ok(response);
        }

        [HttpGet("getById")]
        public IActionResult GetCategory(string id)
        {
            var value = _service.TGetById(id);
            var response = _mapper.Map<GetCategoryDto>(value);
            return Ok(response);
        }

        [HttpPost]
        public IActionResult Create(CreateCategoryDto dto)
        {
            var entity = _mapper.Map<Category>(dto);
            _service.TAdd(entity);
            return Ok("Kategori bilgisi başarı ile eklendi");
        }

        [HttpPut]
        public IActionResult Update(UpdateCategoryDto dto)
        {
            var entity = _mapper.Map<Category>(dto);
            _service.TUpdate(entity);
            return Ok("Kategori bilgisi başarı ile güncellendi");
        }

        [HttpDelete]
        public IActionResult Delete(string id)
        {
            var entity = _service.TGetById(id);
            entity.UpdatedDate = DateTime.Now;
            entity.IsActive = false;
            _service.TUpdate(entity);
            return Ok("Kategori bilgisi silindi");
        }

        //[HttpDelete]
        //public IActionResult HardDelete(string id)
        //{
        //    var value = _service.TGetById(id);
        //    _service.TDelete(value);
        //    return Ok("Kategori bilgisi tamamen silindi");
        //}
    }
}
