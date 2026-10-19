using MediatR;
using Movies.Application.Abstractions;
using Movies.Application.Common.Exceptions;
using Movies.Domain.Movies;

namespace Movies.Application.Movies.Commands.DeleteMovie;

public sealed class DeleteMovieCommandHandler(
    IMovieRepository repository,
    IUnitOfWork unitOfWork) : IRequestHandler<DeleteMovieCommand>
{
    public async Task Handle(DeleteMovieCommand request, CancellationToken cancellationToken)
    {
        var movie = await repository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new NotFoundException(nameof(Movie), request.Id);

        repository.Remove(movie);
        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
