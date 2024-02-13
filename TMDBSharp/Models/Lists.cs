using System.Text.Json.Serialization;

namespace TMDBSharp.Models
{
    public class Lists
    {
        [JsonPropertyName("description ")]
        public string? Description { get; set; }
        [JsonPropertyName("favorite_count ")]
        public int? FavoriteCount { get; set; }
        [JsonPropertyName("id ")]
        public int? Id { get; set; }
        [JsonPropertyName("item_count ")]
        public int? ItemCount { get; set; }
        [JsonPropertyName("iso_639_1 ")]
        public string? Iso_639_1 { get; set; }
        [JsonPropertyName("iso_3166_1 ")]
        public string? Iso_3166_1 { get; set; }
        [JsonPropertyName("list_type ")]
        public string? ListType { get; set; }
        [JsonPropertyName("name ")]
        public string? Name { get; set; }
        [JsonPropertyName("poster_path ")]
        public string? PosterPath { get; set; }
    }
}