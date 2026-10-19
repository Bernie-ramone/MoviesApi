using MediatR;
using Movies.Application.Common.Models;

namespace Movies.Application.Movies.Queries.GetMovies;

public sealed record GetMoviesQuery(int Page = 1, int PageSize = 10) : IRequest<PagedResult<MovieResponse>>;
