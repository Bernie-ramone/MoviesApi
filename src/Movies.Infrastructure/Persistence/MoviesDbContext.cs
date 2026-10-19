using Microsoft.EntityFrameworkCore;
using Movies.Application.Abstractions;
using Movies.Domain.Movies;

namespace Movies.Infrastructure.Persistence;

public sealed class MoviesDbContext(DbContextOptions<MoviesDbContext> options)
    : DbContext(options), IUnitOfWork
{
    public DbSet<Movie> Movies => Set<Movie>();

    protected override void OnModelCreating(ModelBuilder modelBuilder) =>
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(MoviesDbContext).Assembly);
}
