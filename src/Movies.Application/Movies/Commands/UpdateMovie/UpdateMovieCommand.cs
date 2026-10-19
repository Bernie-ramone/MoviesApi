using MediatR;

namespace Movies.Application.Movies.Commands.UpdateMovie;

public sealed record UpdateMovieCommand(
    Guid Id,
    string Title,
    string Director,
    DateOnly ReleaseDate,
    string Genre,
    string Synopsis) : IRequest, IMovieDetails;
