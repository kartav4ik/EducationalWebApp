using EducationalWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace EducationalWebApp.Data
{
    public class MyDBContext: DbContext
    {
        public MyDBContext(DbContextOptions options) : base(options)
        {

        }


        //dependency injection container 
        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Products { get; set; }   
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Product>()
                .HasMany(p => p.Categories)
                .WithMany(p => p.Products)
                .UsingEntity(j => j.ToTable("ProductsCategories"));

            modelBuilder
                .Entity<Product>()
                .HasMany(p => p.Orders)
                .WithMany(p => p.Products)
                .UsingEntity(j => j.ToTable("ProductsOrders"));
        }


    }      
}
