using System.Text.Json.Serialization;

namespace TMDBSharp.Models
{
    public class Changes
    {
        [JsonPropertyName("changes")]
        public List<Change>? changes { get; set; }
        public class Change
        {
            [JsonPropertyName("key")]
            public string? Key { get; set; }
            [JsonPropertyName("items")]
            public List<Item>? Items { get; set; }
        }
        public class Item
        {
            [JsonPropertyName("id")]
            public string? Id { get; set; }
            [JsonPropertyName("action")]
            public string? Action { get; set; }
            [JsonPropertyName("time")]
            public string? Time { get; set; }
            [JsonPropertyName("iso_639_1")]
            public string? Iso_639_1 { get; set; }
            [JsonPropertyName("iso_3166_1")]
            public string? Iso_3166_1 { get; set; }
            [JsonPropertyName("value")]
            public long? Value { get; set; }
            [JsonPropertyName("original_value")]
            public long? OriginalValue { get; set; }
        }
    }
}