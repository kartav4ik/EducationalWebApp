using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EducationalWebApp.Data;
using EducationalWebApp.Models;
using EducationalWebApp.Models.DTO_s;

namespace EducationalWebApp.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class OrderController: ControllerBase
    {
        private readonly MyDBContext _context;
        public OrderController(MyDBContext context)
        {
            _context = context;
        }

        // GET: api/Order
        [HttpGet]
        public async Task<ActionResult<IEnumerable<OrderDTO>>> GetOrders()
        {
            return await _context
                .Orders
                .Select(o => new OrderDTO(o))
                .ToListAsync();
        }

        // DELETE: api/Order/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
//1. add git repo
//2. 2 controllera
//3. Linq sql
//4. sql-ex

/* дописать по-человечески продукт контроллер, в частности методы POST PUT 
 * дописать post put в двух контроллерах
 *
 *
 */