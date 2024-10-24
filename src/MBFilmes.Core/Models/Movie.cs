namespace MBFilmes.Core.Models;

public class Movie
{
    public int TheMovieDbId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Overview { get; set; } = string.Empty;

    public ICollection<Genre> Genres { get; set; } = [];
}
