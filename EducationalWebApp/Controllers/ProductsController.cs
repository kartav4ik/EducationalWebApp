#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EducationalWebApp.Data;
using EducationalWebApp.Models;
using EducationalWebApp.Models.DTO_s;

namespace EducationalWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly MyDBContext _context;

        public ProductsController(MyDBContext context)
        {
            _context = context;
        }

        // GET: api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDTO>>> GetProducts()
        {
            return await _context
                .Products
                .Include(c => c.Categories)
                .Include(o => o.Orders)
                .Select(p => new ProductDTO(p))
                .ToListAsync();
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductDTO>> GetProduct(int id)
        {
            var product = await _context
                .Products
                .Include(c => c.Categories)
                .Include(o => o.Orders)
                .Where(p => p.ProductId.Equals(id))
                .Select(p => new ProductDTO(p))
                .FirstOrDefaultAsync();

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, UpdateProductDTO updProduct) //XYNTA, remake, but its work
        {
            if (id != updProduct.ProductId)
            {
                return BadRequest();
            }

            var product = await _context
                .Products
                .Include(p => p.Categories)
                .Include(o => o.Orders)
                .AsTracking()
                .SingleOrDefaultAsync(p => p.ProductId.Equals(id));

            product.ProductName = updProduct.ProductName;
            product.ProductPrice = updProduct.ProductPrice;

            if(updProduct.CategoriesId != null)
            {
                var categoriesToRemove = product.Categories.ToList();

                foreach (var category in categoriesToRemove)
                {
                    product.Categories.Remove(category);
                }

                var categoryToAdd = await _context
                    .Category
                    .Where(c => updProduct.CategoriesId.Contains(c.CategoryId))
                    .AsTracking()
                    .ToListAsync();

                foreach (var category in categoryToAdd)
                {
                    product.Categories.Add(category);
                }
            }

            if (updProduct.OrdersId != null)
            {
                var ordersToRemove = product.Orders.ToList();

                foreach (var order in ordersToRemove)
                {
                    product.Orders.Remove(order);
                }

                var ordersToAdd = await _context
                    .Orders
                    .Where(c => updProduct.OrdersId.Contains(c.OrderId))
                    .AsTracking()
                    .ToListAsync();

                foreach (var order in ordersToAdd)
                {
                    product.Orders.Add(order);
                }
            }

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Products
        
        [HttpPost]
      /*  public async Task<ActionResult<ProductDTO>> PostProduct(NewProductDTO newProduct)  //ne robit, Сделаю как надо 
        {
            var product = new Product(newProduct);

            foreach(var categoryId in newProduct.CategoriesId)
            {
                var category = await _context
                    .Category
                    .AsTracking()
                    .SingleOrDefaultAsync(c => c.CategoryId == categoryId);
                if (category != null)
                {
                    product.Categories.Add(category);
                }
            }
            foreach(var orderId in newProduct.OrdersId)
            {
                var order = await _context
                    .Orders
                    .AsTracking()
                    .SingleOrDefaultAsync(o => o.OrderId == orderId);
                if (order != null)
                {
                    product.Orders.Add(order);
                }
            }

            _context.Products.Add(product);
            await _context.SaveChangesAsync();  


            return CreatedAtAction(nameof(GetProduct), 
                new { id = product.ProductId},
                new ProductDTO(product));
        }*/

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductExists(int id)
        {
            return _context.Products.Any(e => e.ProductId == id);
        }
    }
}
