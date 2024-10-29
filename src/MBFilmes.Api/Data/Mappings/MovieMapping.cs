using MBFilmes.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MBFilmes.Api.Data.Mappings;

public class MovieMapping : IEntityTypeConfiguration<Movie>
{
    public void Configure(EntityTypeBuilder<Movie> builder)
    {
        builder.ToTable("Movie");

        builder.HasKey(x => x.TheMovieDbId);

        builder.Property(x => x.TheMovieDbId)
            .ValueGeneratedNever();
        
        builder.Property(x => x.Title)
            .IsRequired()
            .HasColumnType("NVARCHAR")
            .HasMaxLength(100);

        builder.Property(x => x.Overview)
            .IsRequired()
            .HasColumnType("NVARCHAR")
            .HasMaxLength(300);

        builder.HasMany(x => x.Genres)
            .WithMany(x => x.Movies)
            .UsingEntity<Dictionary<string, object>>(
                    "MovieGenre",
                    j => j.HasOne<Genre>()
                        .WithMany()
                        .HasForeignKey("GenreId")
                        .HasConstraintName("FK_MovieGenre_Genre_GenreId"),
                    j => j.HasOne<Movie>()
                        .WithMany()
                        .HasForeignKey("MovieId")
                        .HasConstraintName("FK_MovieGenre_Movie_MovieId")
                );
    }
}