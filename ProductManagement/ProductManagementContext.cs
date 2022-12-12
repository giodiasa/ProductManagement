using Microsoft.EntityFrameworkCore;
using ProductManagement.Entities;
using System.Diagnostics.CodeAnalysis;

namespace ProductManagement
{
    public class ProductManagementContext : DbContext
    {
        public ProductManagementContext()
        {

        }
        public ProductManagementContext(DbContextOptions<ProductManagementContext> options)
            : base(options)
        {
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasKey(a => a.Id);
            modelBuilder.Entity<Product>()
                .HasKey(a => a.Id);
            modelBuilder.Entity<Product>()
                .HasOne(a => a.Category)
                .WithMany(b => b.Products);
        }
    }
}
