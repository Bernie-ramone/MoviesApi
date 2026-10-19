using FluentValidation;

namespace Movies.Application.Movies.Queries.GetMovies;

public sealed class GetMoviesQueryValidator : AbstractValidator<GetMoviesQuery>
{
    public const int MaxPageSize = 100;

    public GetMoviesQueryValidator()
    {
        RuleFor(x => x.Page).GreaterThanOrEqualTo(1);
        RuleFor(x => x.PageSize).InclusiveBetween(1, MaxPageSize);
    }
}
