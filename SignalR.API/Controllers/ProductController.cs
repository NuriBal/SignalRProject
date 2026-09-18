using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SignalR.Bussiness.Abstract;
using SignalR.Dto.ProductDto;
using SignalR.Entity.Entities;

namespace SignalR.API.Controllers
{
    [Route("api/products")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;
        private readonly IMapper _mapper;

        public ProductController(IProductService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult List()
        {
            var values = _service.TGetListAll();
            var response = _mapper.Map<List<ResultProductDto>>(values);
            return Ok(response);
        }

        [HttpGet("getProductWithCategory")]
        public IActionResult GetProductsWithCategories()
        {
            var values = _service.TGetProductsWithCategories();
            var response = _mapper.Map<List<ResultProductDto>>(values);
            return Ok(response);
        }

        [HttpGet("getById")]
        public IActionResult GetProduct(string id)
        {
            var value = _service.TGetById(id);
            var response = _mapper.Map<GetProductDto>(value);
            return Ok(response);
        }

        [HttpPost]
        public IActionResult Create(CreateProductDto dto)
        {
            var entity = _mapper.Map<Product>(dto);
            _service.TAdd(entity);
            return Ok("Ürün bilgisi başarı ile eklendi");
        }

        [HttpPut]
        public IActionResult Update(UpdateProductDto dto)
        {
            var entity = _mapper.Map<Product>(dto);
            _service.TUpdate(entity);
            return Ok("Ürün bilgisi başarı ile güncellendi");
        }

        [HttpDelete]
        public IActionResult Delete(string id)
        {
            var entity = _service.TGetById(id);
            entity.UpdatedDate = DateTime.Now;
            entity.IsActive = false;
            _service.TUpdate(entity);
            return Ok("Ürün bilgisi silindi");
        }

        //[HttpDelete]
        //public IActionResult HardDelete(string id)
        //{
        //    var value = _service.TGetById(id);
        //    _service.TDelete(value);
        //    return Ok("Ürün bilgisi tamamen silindi");
        //}
    }
}
