using Lab07.models;
using Lab07.models.movies;
using Microsoft.EntityFrameworkCore;

namespace Lab07.models.products;

public class ProductsContext : DbContext
{
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Producer> Producers => Set<Producer>();

    public ProductsContext(DbContextOptions<ProductsContext> options) : base(options) { }
}