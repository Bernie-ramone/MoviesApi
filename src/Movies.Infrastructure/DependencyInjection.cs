using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Movies.Application.Abstractions;
using Movies.Domain.Movies;
using Movies.Infrastructure.Persistence;
using Movies.Infrastructure.Persistence.Queries;
using Movies.Infrastructure.Persistence.Repositories;

namespace Movies.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("MoviesDb");
        if (string.IsNullOrWhiteSpace(connectionString))
        {
            throw new InvalidOperationException(
                "Connection string 'MoviesDb' is missing. Set it with dotnet user-secrets (see README.md).");
        }

        services.AddDbContext<MoviesDbContext>(options => options.UseSqlServer(connectionString));

        services.AddScoped<IUnitOfWork>(sp => sp.GetRequiredService<MoviesDbContext>());
        services.AddScoped<IMovieRepository, MovieRepository>();
        services.AddScoped<IMovieQueries, MovieQueries>();

        return services;
    }
}
