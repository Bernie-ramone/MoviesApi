using MediatR;
using Movies.Application.Abstractions;
using Movies.Application.Common.Models;

namespace Movies.Application.Movies.Queries.GetMovies;

public sealed class GetMoviesQueryHandler(IMovieQueries queries)
    : IRequestHandler<GetMoviesQuery, PagedResult<MovieResponse>>
{
    public Task<PagedResult<MovieResponse>> Handle(GetMoviesQuery request, CancellationToken cancellationToken) =>
        queries.GetPagedAsync(request.Page, request.PageSize, cancellationToken);
}
