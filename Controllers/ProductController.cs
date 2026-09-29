using ReUseApi.Application.DTOs.Product;
using ReUseApi.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace ReUseApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateProductDto dto)
        {
            var product = await _productService.CreateAsync(dto);

            return Ok(product);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = await _productService.GetAllAsync();

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var product = await _productService.GetByIdAsync(id);

            if (product == null)
                return NotFound();

            return Ok(product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, UpdateProductDto dto)
        {
            var product = await _productService.UpdateAsync(id, dto);

            if (product == null)
                return NotFound();

            return Ok(product);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        { 
            var deleted = await _productService.DeleteAsync(id);

            if (deleted == false)
                return NotFound();

            return Ok(); 
        }
    }
}
