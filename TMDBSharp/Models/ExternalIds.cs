using System.Text.Json.Serialization;

namespace TMDBSharp.Models
{
    public class ExternalIds
    {
        [JsonPropertyName("id")]
        public int? Id { get; set; }
        [JsonPropertyName("imdb_id")]
        public string? IMDBId { get; set; }
        [JsonPropertyName("wikidata_id")]
        public string? WikiDataId { get; set; }
        [JsonPropertyName("facebook_id")]
        public string? FacebookId { get; set; }
        [JsonPropertyName("instagram_id")]
        public string? InstagramId { get; set; }
        [JsonPropertyName("twitter_id")]
        public string? TwitterId { get; set; }
    }
}