namespace MBFilmes.Core.Models;

public class FavoriteMovie
{
    public long Id { get; set; }
    public bool IsWatched { get; set; } = false;

    public long ProfileId { get; set; }
    public Profile Profile { get; set; } = null!;

    public int MovieId { get; set; }
    public Movie Movie { get; set; } = null!;
}
