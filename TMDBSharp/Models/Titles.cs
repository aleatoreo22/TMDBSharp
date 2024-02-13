using System.Text.Json.Serialization;

namespace TMDBSharp.Models
{
    public class Titles
    {
        [JsonPropertyName("iso_3166_1")]
        public string? Iso_3166_1 { get; set; }
        [JsonPropertyName("title")]
        public string? Title { get; set; }
        [JsonPropertyName("type")]
        public string? Type { get; set; }
    }
}