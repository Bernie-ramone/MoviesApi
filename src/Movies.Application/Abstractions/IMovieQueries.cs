using Movies.Application.Common.Models;
using Movies.Application.Movies;

namespace Movies.Application.Abstractions;

// Read side (CQRS): returns DTOs directly, no tracked entities.
public interface IMovieQueries
{
    Task<MovieResponse?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<PagedResult<MovieResponse>> GetPagedAsync(int page, int pageSize, CancellationToken cancellationToken = default);
}
