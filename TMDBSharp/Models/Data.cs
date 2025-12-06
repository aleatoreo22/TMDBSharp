using System.Text.Json.Serialization;

namespace TMDBSharp.Models;

public class Data
{
    [JsonPropertyName("biography")]
    public string? Biography { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }
}
