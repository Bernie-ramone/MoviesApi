using FluentValidation;

namespace Movies.Application.Movies.Commands.CreateMovie;

public sealed class CreateMovieCommandValidator : AbstractValidator<CreateMovieCommand>
{
    public CreateMovieCommandValidator()
    {
        Include(new MovieDetailsValidator());
    }
}
