namespace Movies.Application.Movies;

// Shared shape of Create and Update commands, so both reuse one validator (DRY).
public interface IMovieDetails
{
    string Title { get; }
    string Director { get; }
    DateOnly ReleaseDate { get; }
    string Genre { get; }
    string Synopsis { get; }
}
