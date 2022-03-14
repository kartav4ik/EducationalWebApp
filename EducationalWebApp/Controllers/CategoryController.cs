using AppDomain.Models;
using AppDomain.Models.DTO_s;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;

namespace WebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<ActionResult<GetAllCategoryDTO>> GetCategories()
        {
            var response = await _categoryService.GetCategories();
            var data = response.Data.Select(p => GetAllCategoryDTO.New(p));
            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<GetOneCategoryDTO>> GetCategory(Guid id)
        {
            var response = await _categoryService.GetCategory(id);
            if (response.Data == null)
            {
                return NotFound();
            }
            var data = GetOneCategoryDTO.New(response.Data);
            return Ok(data);
        }

        [HttpPost]
        public async Task<ActionResult<NewCategoryDTO>> AddCategory(Category newCategory)
        {
            var response = await _categoryService.AddCategory(newCategory);
            var data = NewCategoryDTO.New(response.Data);
            return Ok(data);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditCategory(Guid id, Category updCategory)
        {
            var response = await _categoryService.EditCategory(id, updCategory);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            var response = await _categoryService.DeleteCategory(id);
            return Ok(response);
        }

    }
}
