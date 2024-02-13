using System.Text.Json.Serialization;

namespace TMDBSharp.Models
{
    public class Keyword
    {
        [JsonPropertyName("id")]
        public int? Id { get; set; }
        [JsonPropertyName("name")]
        public string? Name { get; set; }
    }
}