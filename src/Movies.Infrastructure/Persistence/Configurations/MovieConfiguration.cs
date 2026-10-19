using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Movies.Domain.Movies;

namespace Movies.Infrastructure.Persistence.Configurations;

// Maps to the existing dbo.movies table (database-first, no migrations).
public sealed class MovieConfiguration : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.ToTable("movies", "dbo");

        builder.HasKey(m => m.Id).HasName("PK_movies");
        builder.Property(m => m.Id).ValueGeneratedNever();

        builder.Property(m => m.Title).IsRequired().HasMaxLength(MovieConstraints.TitleMaxLength);
        builder.Property(m => m.Director).IsRequired().HasMaxLength(MovieConstraints.DirectorMaxLength);
        builder.Property(m => m.ReleaseDate).IsRequired().HasColumnType("date");
        builder.Property(m => m.Genre).IsRequired().HasMaxLength(MovieConstraints.GenreMaxLength);
        builder.Property(m => m.Synopsis).IsRequired().HasMaxLength(MovieConstraints.SynopsisMaxLength);
        builder.Property(m => m.AverageRating).HasColumnType("float");
        builder.Property(m => m.RatingCount);
        builder.Property(m => m.CreatedAtUtc).IsRequired().HasColumnType("datetime2(7)");
    }
}
