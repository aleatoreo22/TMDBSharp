using System.Text.Json.Serialization;

namespace TMDBSharp.Models
{
    public class Image
    {
        [JsonPropertyName("width")]
        public double? AspectRatio { get; set; }
        [JsonPropertyName("vote_count")]
        public int? Height { get; set; }
        [JsonPropertyName("vote_average")]
        public string? Iso_639_1 { get; set; }
        [JsonPropertyName("file_path")]
        public string? FilePath { get; set; }
        [JsonPropertyName("iso_639_1")]
        public double? VoteAverage { get; set; }
        [JsonPropertyName("height")]
        public int? VoteCount { get; set; }
        [JsonPropertyName("aspect_ratio")]
        public int? Width { get; set; }
    }
}