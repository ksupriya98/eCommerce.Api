using eCommerce.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Api.Dal;

public class eCommerceApiDbContext : DbContext
{
    public eCommerceApiDbContext()
    {

    }
    public eCommerceApiDbContext(DbContextOptions<eCommerceApiDbContext> options) : base(options)
    {

    }

    public DbSet<Category> Categories { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<Customer> Customers { get; set; } = null!;
    public DbSet<Cart> Carts { get; set; } = null!;
    public DbSet<CartItem> CartItems { get; set; } = null!;
    public DbSet<Invoice> Invoices { get; set; } = null!;
    public DbSet<Shipper> Shippers { get; set; } = null!;
    public DbSet<Supplier> Suppliers { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Seed();
    }
}
