using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EducationalWebApp.Data;
using EducationalWebApp.Models;
using EducationalWebApp.Models.DTO_s;


namespace EducationalWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController: ControllerBase
    {
        private readonly MyDBContext _context;
        public CategoryController(MyDBContext context)
        {
            _context = context;
        }

        // GET: api/Category
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetCategory()
        {
            return await _context
                .Category
                .Select(c => new CategoryDTO(c))
                .ToListAsync();
        }

        // DELETE: api/Category/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _context.Category.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }

            _context.Category.Remove(category);
            await _context.SaveChangesAsync();

            return NoContent();
        }

    }
}
