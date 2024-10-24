namespace MBFilmes.Core.Models;

public class Movie
{
    public long Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Overview { get; set; } = string.Empty;
    public string Gender { get; set; } = string.Empty;
    public bool IsFavorite { get; set; } = false;
    public bool IsWatched { get; set; } = false;

    public long ProfileId { get; set; }
    public Profile Profile { get; set; } = null!;
}
