using System.Text.Json.Serialization;

namespace TMDBSharp.Models;

public class Genre
{
    [JsonPropertyName("id")]
    public int? Id { get; set; }
    [JsonPropertyName("id")]
    public string? Name { get; set; }
}