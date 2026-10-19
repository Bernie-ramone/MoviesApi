using MediatR;
using Movies.Application.Common.Models;
using Movies.Application.Movies;
using Movies.Application.Movies.Commands.CreateMovie;
using Movies.Application.Movies.Commands.DeleteMovie;
using Movies.Application.Movies.Commands.UpdateMovie;
using Movies.Application.Movies.Queries.GetMovieById;
using Movies.Application.Movies.Queries.GetMovies;

namespace Movies.Api.Endpoints;

public static class MovieEndpoints
{
    public static IEndpointRouteBuilder MapMovieEndpoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/movies").WithTags("Movies");

        group.MapGet("/", GetMovies)
            .WithName(nameof(GetMovies))
            .Produces<PagedResult<MovieResponse>>()
            .ProducesValidationProblem();

        group.MapGet("/{id:guid}", GetMovieById)
            .WithName(nameof(GetMovieById))
            .Produces<MovieResponse>()
            .ProducesProblem(StatusCodes.Status404NotFound);

        group.MapPost("/", CreateMovie)
            .WithName(nameof(CreateMovie))
            .Produces<MovieResponse>(StatusCodes.Status201Created)
            .ProducesValidationProblem();

        group.MapPut("/{id:guid}", UpdateMovie)
            .WithName(nameof(UpdateMovie))
            .Produces(StatusCodes.Status204NoContent)
            .ProducesValidationProblem()
            .ProducesProblem(StatusCodes.Status404NotFound);

        group.MapDelete("/{id:guid}", DeleteMovie)
            .WithName(nameof(DeleteMovie))
            .Produces(StatusCodes.Status204NoContent)
            .ProducesProblem(StatusCodes.Status404NotFound);

        return app;
    }

    private static async Task<IResult> GetMovies(
        ISender sender, CancellationToken ct, int page = 1, int pageSize = 10) =>
        Results.Ok(await sender.Send(new GetMoviesQuery(page, pageSize), ct));

    private static async Task<IResult> GetMovieById(Guid id, ISender sender, CancellationToken ct) =>
        Results.Ok(await sender.Send(new GetMovieByIdQuery(id), ct));

    private static async Task<IResult> CreateMovie(CreateMovieCommand command, ISender sender, CancellationToken ct)
    {
        var id = await sender.Send(command, ct);
        var movie = await sender.Send(new GetMovieByIdQuery(id), ct);
        return Results.CreatedAtRoute(nameof(GetMovieById), new { id }, movie);
    }

    private static async Task<IResult> UpdateMovie(
        Guid id, UpdateMovieRequest request, ISender sender, CancellationToken ct)
    {
        await sender.Send(request.ToCommand(id), ct);
        return Results.NoContent();
    }

    private static async Task<IResult> DeleteMovie(Guid id, ISender sender, CancellationToken ct)
    {
        await sender.Send(new DeleteMovieCommand(id), ct);
        return Results.NoContent();
    }
}
