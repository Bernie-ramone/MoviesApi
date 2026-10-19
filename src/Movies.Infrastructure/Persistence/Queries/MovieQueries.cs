using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Movies.Application.Abstractions;
using Movies.Application.Common.Models;
using Movies.Application.Movies;
using Movies.Domain.Movies;

namespace Movies.Infrastructure.Persistence.Queries;

public sealed class MovieQueries(MoviesDbContext context) : IMovieQueries
{
    // Translated to SQL, so only the needed columns are selected.
    private static readonly Expression<Func<Movie, MovieResponse>> ToResponse = m => new MovieResponse(
        m.Id,
        m.Title,
        m.Director,
        m.ReleaseDate,
        m.Genre,
        m.Synopsis,
        m.AverageRating,
        m.RatingCount,
        m.CreatedAtUtc);

    public Task<MovieResponse?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default) =>
        context.Movies
            .AsNoTracking()
            .Where(m => m.Id == id)
            .Select(ToResponse)
            .FirstOrDefaultAsync(cancellationToken);

    public async Task<PagedResult<MovieResponse>> GetPagedAsync(
        int page,
        int pageSize,
        CancellationToken cancellationToken = default)
    {
        var query = context.Movies.AsNoTracking();

        var totalCount = await query.CountAsync(cancellationToken);

        var items = await query
            .OrderByDescending(m => m.CreatedAtUtc)
            .ThenBy(m => m.Id)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .Select(ToResponse)
            .ToListAsync(cancellationToken);

        return new PagedResult<MovieResponse>(items, page, pageSize, totalCount);
    }
}
