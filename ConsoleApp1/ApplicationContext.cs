using AppDomain.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess
{
    public class ApplicationContext: DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {

        }


        //dependency injection container 
        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Products { get; set; }   
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("decimal(18,4)");

            modelBuilder.Entity<Order>()
                .Property(p => p.OrderDate)
                .HasColumnType("Date");

            modelBuilder.Entity<Order>()
                .Property(p => p.ShipmentDate)
                .HasColumnType("Date");

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
