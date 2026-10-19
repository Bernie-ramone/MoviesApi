using MediatR;

namespace Movies.Application.Movies.Queries.GetMovieById;

public sealed record GetMovieByIdQuery(Guid Id) : IRequest<MovieResponse>;
