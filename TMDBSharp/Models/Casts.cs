using System.Text.Json.Serialization;

namespace TMDBSharp.Models;

public class Casts
{
    [JsonPropertyName("cast")]
    public List<Cast>? Cast { get; set; }

    [JsonPropertyName("crew")]
    public List<Crew>? Crew { get; set; }

    [JsonPropertyName("id")]
    public int Id { get; set; }
}
