using MediatR;

namespace Movies.Application.Movies.Commands.DeleteMovie;

public sealed record DeleteMovieCommand(Guid Id) : IRequest;
