using System.Text.Json.Serialization;

namespace TMDBSharp.Models
{
    public class ReleaseDates
    {
        [JsonPropertyName("iso_3166_1")]
        public string? Iso_3166_1 { get; set; }
        [JsonPropertyName("release_dates")]
        public List<ReleaseDate>? ReleaseDate { get; set; }
    }
}