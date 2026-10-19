using MediatR;
using Movies.Application.Abstractions;
using Movies.Domain.Movies;

namespace Movies.Application.Movies.Commands.CreateMovie;

public sealed class CreateMovieCommandHandler(
    IMovieRepository repository,
    IUnitOfWork unitOfWork,
    TimeProvider timeProvider) : IRequestHandler<CreateMovieCommand, Guid>
{
    public async Task<Guid> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
    {
        var movie = Movie.Create(
            request.Title,
            request.Director,
            request.ReleaseDate,
            request.Genre,
            request.Synopsis,
            timeProvider.GetUtcNow().UtcDateTime);

        repository.Add(movie);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return movie.Id;
    }
}
