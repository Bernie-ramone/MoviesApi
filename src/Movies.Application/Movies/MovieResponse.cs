namespace Movies.Application.Movies;

public sealed record MovieResponse(
    Guid Id,
    string Title,
    string Director,
    DateOnly ReleaseDate,
    string Genre,
    string Synopsis,
    double? AverageRating,
    int? RatingCount,
    DateTime CreatedAtUtc);
