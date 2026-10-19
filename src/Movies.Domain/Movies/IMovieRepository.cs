namespace Movies.Domain.Movies;

// Write-side repository: works with the aggregate only.
public interface IMovieRepository
{
    Task<Movie?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    void Add(Movie movie);
    void Remove(Movie movie);
}
