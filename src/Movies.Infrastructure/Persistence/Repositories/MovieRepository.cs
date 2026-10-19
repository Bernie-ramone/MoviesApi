using Movies.Domain.Movies;

namespace Movies.Infrastructure.Persistence.Repositories;

public sealed class MovieRepository(MoviesDbContext context) : IMovieRepository
{
    public async Task<Movie?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default) =>
        await context.Movies.FindAsync([id], cancellationToken);

    public void Add(Movie movie) => context.Movies.Add(movie);

    public void Remove(Movie movie) => context.Movies.Remove(movie);
}
