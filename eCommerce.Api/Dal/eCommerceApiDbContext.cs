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

    public DbSet<Category> Categories { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseMySQL("Server=192.168.100.99;Port=3306;Database=ECommerceDb;User Id=saleel;Password=saleel;");
        }
    }
}
