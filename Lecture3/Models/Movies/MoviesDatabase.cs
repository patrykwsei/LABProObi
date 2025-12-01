using Microsoft.EntityFrameworkCore;

namespace Lecture3.Models.Movies;

public class MoviesDatabase: DbContext
{
    public DbSet<MovieEntity> Movies { get; set; }
    
    public MoviesDatabase(DbContextOptions options) : base(options)
    {
    }
}