using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data;

public class AppDbContext : DbContext
{
    public DbSet<ProductEntity> Products => Set<ProductEntity>();
    public DbSet<ProducerEntity> Producers => Set<ProducerEntity>();

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProductEntity>()
            .HasOne(p => p.Producer)
            .WithMany(p => p.Products)
            .HasForeignKey(p => p.ProducerId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<ProducerEntity>().HasData(
            new ProducerEntity { Id = 1, Name = "Brak" },
            new ProducerEntity { Id = 2, Name = "Janex" },
            new ProducerEntity { Id = 3, Name = "Samsung" }
        );

        base.OnModelCreating(modelBuilder);
    }
}