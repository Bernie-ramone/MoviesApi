using FluentValidation;

namespace Movies.Application.Movies.Commands.UpdateMovie;

public sealed class UpdateMovieCommandValidator : AbstractValidator<UpdateMovieCommand>
{
    public UpdateMovieCommandValidator()
    {
        RuleFor(x => x.Id).NotEmpty();
        Include(new MovieDetailsValidator());
    }
}
