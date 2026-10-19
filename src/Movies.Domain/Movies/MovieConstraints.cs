namespace Movies.Domain.Movies;

// Single source of truth for column limits: used by the EF mapping and the validators.
public static class MovieConstraints
{
    public const int TitleMaxLength = 200;
    public const int DirectorMaxLength = 150;
    public const int GenreMaxLength = 40;
    public const int SynopsisMaxLength = 2000;
}
