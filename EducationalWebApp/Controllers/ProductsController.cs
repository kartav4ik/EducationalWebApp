#nullable disable
using AppDomain.Models;
using AppDomain.Models.DTO_s;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace WebApi.Controllers
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

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<ProductDTO>> GetProducts()
        {
            var response = await _productService.GetProducts();
            var data = response.Data.Select(p => ProductDTO.New(p));
            return Ok(data);
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetProduct(Guid id)
        {
            var response = await _productService.GetProduct(id);
            if (response.Data == null)
            {
                return NotFound();
            }
            var data = ProductDTO.New(response.Data);
            return Ok(data);
        }

        [HttpPost]
        public async Task<ActionResult<ProductDTO>> AddProduct(Product newProduct)
        {
            var response = await _productService.AddProduct(newProduct);
            var data = ProductDTO.New(response.Data);
            return Ok(data);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditProduct(Guid id, Product updProduct)
        {
            var response = await _productService.EditProduct(id, updProduct);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            var response = await _productService.DeleteProduct(id);
            return Ok(response);
        }
    }
}



      