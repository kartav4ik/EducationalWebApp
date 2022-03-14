using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppDomain.Models;
using DataAccess.Interfaces;

namespace DataAccess.Repositories
{
    public class CategoryRepository :  ICategoryRepository
    {
        private ApplicationContext _context;

        public CategoryRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<Category> Add(Category newCategory)
        {
            var category = Category.New(newCategory.Name);

            foreach (var product in newCategory.Products)
            {
                var product2 = await _context
                    .Products
                    .AsTracking()
                    .SingleOrDefaultAsync(p => p.Id == product.Id);
                category.Products.Add(product2);
            }

            _context.Category.Add(category);
            await _context.SaveChangesAsync();

            return category;
        }

        public async Task<Category> Get(Guid id)
        {
            var category = _context
                .Category
                .Include(p => p.Products)
                .Where(p => p.Id.Equals(id))
                .Select(p => Category.New(p))
                .FirstOrDefaultAsync();

            return await category;
        }

        public async Task<List<Category>> GetAll()
        {
            return await _context
               .Category
               .Include(p => p.Products)
               .Select(o => Category.New(o))
               .ToListAsync(); 
        }

        public Task<bool> Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<Category> Update(Guid id, Category updCategory)
        {
            var category = await _context
                    .Category
                    .Include(p => p.Products)
                    .AsTracking()
                    .SingleOrDefaultAsync(p => p.Id.Equals(id));
            if (category == null)
            {
                return null;
            }
            category.Name = updCategory.Name;

            var productToAdd = await _context
                .Products
                .Where(p => updCategory.Products.Contains(p))
                .AsTracking()
                .ToListAsync();
            var productToRemove = category.Products.ToList();

            foreach (var product in productToRemove)
            {
                category.Products.Remove(product);
            }

            foreach (var product in productToAdd)
            {
                category.Products.Add(product);
            }

            if (updCategory.Products == null)
            {
                foreach (var product in updCategory.Products)
                {
                    category.Products.Remove(product);
                }
            }
            try
            {
                await _context.SaveChangesAsync();
                return category;
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
    }
}
