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
    public class OrderRepository : IOrderRepository
    {
        private ApplicationContext _context;

        public OrderRepository(ApplicationContext context)
        {
            _context = context;
        }
        public async Task<Order> Add(Order newOrder)
        {
            var order = Order.New(newOrder.ShipmentDate, newOrder.OrderDate);

            foreach (var product in newOrder.Products)
            {
                var product2 = await _context
                    .Products
                    .AsTracking()
                    .SingleOrDefaultAsync(p => p.Id == product.Id);
                order.Products.Add(product2);
            }

            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return order;
        }
       
        public async Task<Order> Get(Guid id)
        {
            var order = _context
                .Orders         
                .Include(p => p.Products)
                .Where(p => p.Id.Equals(id))
                .Select(p => Order.New(p))
                .FirstOrDefaultAsync();

            return await order; 
        }

        public async Task<List<Order>> GetAll()
        {
            return await _context
               .Orders
               .Include(p => p.Products)
               .Select(o => Order.New(o))
               .ToListAsync();
        }
        public async Task<Order> Update(Guid id, Order updOrder)
        {
            var order = await _context
                    .Orders
                    .Include(p => p.Products)
                    .AsTracking()
                    .SingleOrDefaultAsync(p => p.Id.Equals(id));
            if(order == null)
            {
                return null;
            }
            order.OrderDate = updOrder.OrderDate;
            order.ShipmentDate = updOrder.ShipmentDate;
            var productToAdd = await _context
                .Products
                .Where(p => updOrder.Products.Contains(p))
                .AsTracking()
                .ToListAsync();
            var productToRemove = order.Products.ToList();

            foreach (var product in productToRemove)
            {
                order.Products.Remove(product);
            }

            foreach (var product in productToAdd)
            {
                order.Products.Add(product);
            }

            if (updOrder.Products == null)
            {
                foreach (var product in updOrder.Products)
                {
                    order.Products.Remove(product);
                }
            }
            try
            {
                await _context.SaveChangesAsync();
                return order;
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
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return false;
            }
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return true;
        }

    }
}
