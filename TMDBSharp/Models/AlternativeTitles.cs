using System.Text.Json.Serialization;

namespace TMDBSharp.Models;

public class AlternativeTitles
{
    [JsonPropertyName("id")]
    public int? Id { get; set; }

    [JsonPropertyName("titles")]
    public List<Titles>? Titles { get; set; }
}
