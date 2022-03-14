using AppDomain.Models;
using DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private ApplicationContext _context;

        public ProductRepository(ApplicationContext context)
        {
           _context = context;
        }

        public async Task<Product> Get(Guid id)
        {
            var product = _context
                .Products
                .Include(c => c.Categories)
                .Include(o => o.Orders)
                .Where(p => p.Id.Equals(id))
                .Select(p => Product.New(p))
                .FirstOrDefaultAsync();

            return await product;

        }

        public async Task<Product> Add(Product newProduct)
        {
            var product = Product.New(newProduct.Name, newProduct.Price);
            _context.Add(product);
            await _context.SaveChangesAsync();

            return product;

        } 
         
        public async Task<List<Product>> GetAll()
        {
            return await _context
                .Products
                .Include(c => c.Categories)
                .Include(o => o.Orders)
                .Select(p => Product.New(p))
                .ToListAsync();

        }

        public async Task<Product> Update(Guid id, Product updProduct)
        {
            var product = await _context
                .Products
                .AsTracking()
                .SingleOrDefaultAsync(p => p.Id.Equals(id));
            if (product == null)
            {
                return null;
            }
            product.Name = updProduct.Name;
            product.Price = updProduct.Price;
            try
            {
                await _context.SaveChangesAsync();
                return product;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!(_context.Products.Any(e => e.Id == id)))
                {
                    return null;
                }
                else
                {
                    throw;
                }

            }
        }

        public async Task<bool> Remove(Guid id)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return false;
            }
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            
            return true;
        }
    }
}


