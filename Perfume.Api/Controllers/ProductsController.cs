using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Perfume.Api.Dtos;
using Perfume.Api.Services;

using Microsoft.AspNetCore.Authorization;
namespace Perfume.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;


        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _productService.GetAllAsync());
        }
        [HttpGet("{id}")]

        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product is null)
                return NotFound();
            return Ok(product);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Create(CreateProductDto dto)
        {
            var product = await _productService.CreateAsync(dto);
            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }
        [HttpPut("{id}")]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Update(CreateProductDto dto,int id )

        {

            var updated = await _productService.UpdateAsync(id, dto);
            if(!updated)
                return NotFound();
            return NoContent();
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]

        public async Task<IActionResult> Delete(int id)
        {
            var removeProduct = await _productService.DeleteAsync(id);
            if(!removeProduct)
                return NotFound();
            return NoContent();
        }
    }
}
