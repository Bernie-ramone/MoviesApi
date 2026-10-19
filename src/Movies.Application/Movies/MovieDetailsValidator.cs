using FluentValidation;
using Movies.Domain.Movies;

namespace Movies.Application.Movies;

public sealed class MovieDetailsValidator : AbstractValidator<IMovieDetails>
{
    public MovieDetailsValidator()
    {
        RuleFor(x => x.Title).NotEmpty().MaximumLength(MovieConstraints.TitleMaxLength);
        RuleFor(x => x.Director).NotEmpty().MaximumLength(MovieConstraints.DirectorMaxLength);
        RuleFor(x => x.Genre).NotEmpty().MaximumLength(MovieConstraints.GenreMaxLength);
        RuleFor(x => x.Synopsis).NotEmpty().MaximumLength(MovieConstraints.SynopsisMaxLength);
        RuleFor(x => x.ReleaseDate).NotEmpty();
    }
}
