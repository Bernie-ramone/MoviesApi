using MediatR;
using Movies.Application.Abstractions;
using Movies.Application.Common.Exceptions;
using Movies.Domain.Movies;

namespace Movies.Application.Movies.Queries.GetMovieById;

public sealed class GetMovieByIdQueryHandler(IMovieQueries queries)
    : IRequestHandler<GetMovieByIdQuery, MovieResponse>
{
    public async Task<MovieResponse> Handle(GetMovieByIdQuery request, CancellationToken cancellationToken) =>
        await queries.GetByIdAsync(request.Id, cancellationToken)
            ?? throw new NotFoundException(nameof(Movie), request.Id);
}
