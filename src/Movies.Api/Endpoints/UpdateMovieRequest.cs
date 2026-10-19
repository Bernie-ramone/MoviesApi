using Movies.Application.Movies.Commands.UpdateMovie;

namespace Movies.Api.Endpoints;

// Body of PUT /api/movies/{id}; the id comes from the route.
public sealed record UpdateMovieRequest(
    string Title,
    string Director,
    DateOnly ReleaseDate,
    string Genre,
    string Synopsis)
{
    public UpdateMovieCommand ToCommand(Guid id) =>
        new(id, Title, Director, ReleaseDate, Genre, Synopsis);
}
