using MediatR;
using Movies.Application.Abstractions;
using Movies.Application.Common.Exceptions;
using Movies.Domain.Movies;

namespace Movies.Application.Movies.Commands.UpdateMovie;

public sealed class UpdateMovieCommandHandler(
    IMovieRepository repository,
    IUnitOfWork unitOfWork) : IRequestHandler<UpdateMovieCommand>
{
    public async Task Handle(UpdateMovieCommand request, CancellationToken cancellationToken)
    {
        var movie = await repository.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new NotFoundException(nameof(Movie), request.Id);

        movie.Update(
            request.Title,
            request.Director,
            request.ReleaseDate,
            request.Genre,
            request.Synopsis);

        await unitOfWork.SaveChangesAsync(cancellationToken);
    }
}
