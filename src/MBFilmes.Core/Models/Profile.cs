using System.Text.Json.Serialization;

namespace MBFilmes.Core.Models;

public class Profile
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public string UserId { get; set; } = string.Empty;

    [JsonIgnore]
    public ICollection<WatchList> WatchLists { get; set; } = [];
}
