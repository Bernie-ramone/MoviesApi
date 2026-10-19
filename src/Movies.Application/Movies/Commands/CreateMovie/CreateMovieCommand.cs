using MediatR;

namespace Movies.Application.Movies.Commands.CreateMovie;

public sealed record CreateMovieCommand(
    string Title,
    string Director,
    DateOnly ReleaseDate,
    string Genre,
    string Synopsis) : IRequest<Guid>, IMovieDetails;
