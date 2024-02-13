using System.Text.Json.Serialization;

namespace TMDBSharp.Models
{
    public class Images
    {
        [JsonPropertyName("backdrops")]
        public List<Image>? Backdrops { get; set; }
        [JsonPropertyName("id")]
        public int? Id { get; set; }
        [JsonPropertyName("logos")]
        public List<Image>? Logos { get; set; }
        [JsonPropertyName("posters")]
        public List<Image>? Posters { get; set; }
    }
}