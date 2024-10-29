using MBFilmes.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MBFilmes.Api.Data.Mappings;

public class WatchListMapping : IEntityTypeConfiguration<WatchList>
{
    public void Configure(EntityTypeBuilder<WatchList> builder)
    {
        builder.ToTable("WatchList");
        
        builder.HasKey(x => x.Id);

        builder.Property(x => x.IsWatched)
            .IsRequired()
            .HasDefaultValue(false);
    }
}