using System.Text.Json.Serialization;
using TMDBSharp.Core.Enum;

namespace TMDBSharp.Models
{
    public class ReleaseDate
    {
        [JsonPropertyName("certification")]
        public string? Certification { get; set; }
        [JsonPropertyName("descriptors")]
        public List<string>? Descriptors { get; set; }
        [JsonPropertyName("iso_639_1")]
        public string? Iso_639_1 { get; set; }
        [JsonPropertyName("note")]
        public string? Note { get; set; }
        [JsonPropertyName("release_date")]
        public DateTime? Release_Date { get; set; }
        [JsonPropertyName("type")]
        public RelaseTypes? Type { get; set; }
    }
}