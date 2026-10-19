namespace Movies.Domain.Movies;

public sealed class Movie
{
    public Guid Id { get; private set; }
    public string Title { get; private set; } = null!;
    public string Director { get; private set; } = null!;
    public DateOnly ReleaseDate { get; private set; }
    public string Genre { get; private set; } = null!;
    public string Synopsis { get; private set; } = null!;
    public double? AverageRating { get; private set; }
    public int? RatingCount { get; private set; }
    public DateTime CreatedAtUtc { get; private set; }

    // Required by EF Core.
    private Movie() { }

    public static Movie Create(
        string title,
        string director,
        DateOnly releaseDate,
        string genre,
        string synopsis,
        DateTime createdAtUtc)
    {
        var movie = new Movie
        {
            Id = Guid.CreateVersion7(),
            CreatedAtUtc = createdAtUtc
        };

        movie.Update(title, director, releaseDate, genre, synopsis);
        return movie;
    }

    public void Update(
        string title,
        string director,
        DateOnly releaseDate,
        string genre,
        string synopsis)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(title);
        ArgumentException.ThrowIfNullOrWhiteSpace(director);
        ArgumentException.ThrowIfNullOrWhiteSpace(genre);
        ArgumentException.ThrowIfNullOrWhiteSpace(synopsis);

        Title = title.Trim();
        Director = director.Trim();
        ReleaseDate = releaseDate;
        Genre = genre.Trim();
        Synopsis = synopsis.Trim();
    }
}
